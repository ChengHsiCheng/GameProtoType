using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    private readonly float previousFrameTime; // 上一幀的正規化時間
    private readonly Attack attack; // 攻擊的資訊
    private bool isMoved;


    public PlayerAttackState(PlayerStateMachine stateMachine, int attackIndex) : base(stateMachine)
    {
        attack = stateMachine.Attacks[attackIndex];
    }

    public override void Enter()
    {
        stateMachine.SetCanAction(false);

        stateMachine.Animator.CrossFadeInFixedTime(attack.AnimationName, attack.TransitionDuration);

        stateMachine.Weapon.SetAttack(attack.Damage + (attack.Damage * stateMachine.sanScalingDamage));
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Attack");

        Move(deltaTime);

        if (!isMoved && normalizedTime > attack.MoveTime)
        {
            stateMachine.ForceReceiver.AddForce(stateMachine.transform.forward * attack.MoveForce);
            isMoved = true;
        }

        if (normalizedTime >= previousFrameTime && normalizedTime < 1f)
        {
            if (stateMachine.InputReader.IsAttacking)
            {
                TryComboAttack(normalizedTime);

                return;
            }
        }

        if (normalizedTime <= attack.minCancelTime)
            return;

        if (stateMachine.canCancel)
            stateMachine.SetCanCancel(false);

        if (normalizedTime < attack.MinComboAttackTime + 0.1f)
            return;

        if (!CanAction)
            stateMachine.SetCanAction(true);

        if (stateMachine.InputReader.MovementValue != Vector2.zero || normalizedTime >= 1f)
        {
            stateMachine.SwitchState(new PlayerMovingState(stateMachine));
        }

    }

    public override void Exit()
    {
        attack.Model.transform.position = stateMachine.transform.position;

        stateMachine.SetCanCancel(true);
    }

    /// <summary>
    /// 嘗試繼續攻擊
    /// </summary>
    private void TryComboAttack(float normalizedTime)
    {
        if (attack.ComboStateIndex == -1)
            return;

        if (normalizedTime < attack.MinComboAttackTime || normalizedTime > attack.MaxComboAttackTime)
            return;

        stateMachine.SwitchState(new PlayerAttackState(stateMachine, attack.ComboStateIndex));
    }

}
