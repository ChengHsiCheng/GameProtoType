using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    private readonly float previousFrameTime; // 上一幀的正規化時間
    private readonly Attack attack; // 攻擊的資訊
    private bool isMoved;
    private bool isAttack;


    public PlayerAttackState(PlayerStateMachine stateMachine, int attackIndex) : base(stateMachine)
    {
        attack = stateMachine.Attacks[attackIndex];
    }

    public override void Enter()
    {
        stateMachine.SetCanAction(false);

        stateMachine.Animator.CrossFadeInFixedTime(attack.AnimationName, attack.TransitionDuration);

        stateMachine.Weapon.SetAttack(attack.Damage + (attack.Damage * stateMachine.sanScalingDamage), 0, 0, attack.ShockingPower);

        if (attack.AnimationName == "Attack3")
            stateMachine.Weapon.SetStuckFrame(0.1f);
        else
            stateMachine.Weapon.SetStuckFrame();
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Attack");

        Move(deltaTime);

        Vector3 movemnt = CalculateMovement();

        if (normalizedTime >= attack.AttackTimeByAnimation && !isAttack)
        {
            stateMachine.WeaponHendler.EnableWeapon(0);
            isAttack = true;
        }

        if (normalizedTime <= attack.RotateTime && movemnt != Vector3.zero)
        {
            FaceMovementDirection(movemnt, deltaTime);
        }

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

        // if (normalizedTime <= attack.PreCancelTime)
        // {
        //     if (stateMachine.canCancel)
        //         stateMachine.SetCanCancel(false);

        //     return;
        // }
        // else if (normalizedTime < attack.PostCancelTime)
        // {
        //     if (!stateMachine.canCancel)
        //         stateMachine.SetCanCancel(true);

        //     return;
        // }

        if (normalizedTime < attack.PreCancelTime || normalizedTime > attack.PostCancelTime)
        {
            if (!stateMachine.canCancel)
                stateMachine.SetCanCancel(true);
        }
        else
        {
            if (stateMachine.canCancel)
                stateMachine.SetCanCancel(false);

            return;
        }

        if (!CanAction)
            stateMachine.SetCanAction(true);

        if (normalizedTime >= 1f)
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
