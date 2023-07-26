using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    private float previousFrameTime; // 上一幀的正規化時間
    private Attack attack; // 攻擊的資訊

    public PlayerAttackState(PlayerStateMachine stateMachine, int attackIndex) : base(stateMachine)
    {
        attack = stateMachine.Attacks[attackIndex];
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(attack.AnimationName, attack.TransitionDuration);

        stateMachine.Weapon.SetAttack(attack.Damage + (attack.Damage * stateMachine.sanScalingDamage));
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Attack");

        if (normalizedTime >= previousFrameTime && normalizedTime < 1f)
        {
            if (stateMachine.InputReader.IsAttacking)
            {
                TryComboAttack(normalizedTime);

                return;
            }
        }

        if (normalizedTime >= attack.MinComboAttackTime && !canAction)
        {
            stateMachine.SetCanAction(true);
        }

        if (normalizedTime >= attack.minCancelTime && normalizedTime <= attack.MinComboAttackTime)
        {
            stateMachine.SetCanAction(false);
        }

        if (!canAction)
            return;

        if (stateMachine.InputReader.MovementValue != Vector2.zero || normalizedTime >= 1f)
        {
            stateMachine.SwitchState(new PlayerMovingState(stateMachine));
        }

    }

    public override void Exit()
    {
        attack.Model.transform.position = stateMachine.transform.position;
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
