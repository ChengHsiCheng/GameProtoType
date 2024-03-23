using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    private readonly float previousFrameTime; // 上一幀的正規化時間
    private readonly Attack attack; // 攻擊的資訊
    private bool isMoved;
    private bool isAudio;
    private bool isAttack;
    private int nextAttack = -1;


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
            stateMachine.Weapon.SetStuckFrame(0.2f);
        else
            stateMachine.Weapon.SetStuckFrame(0.1f);
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Attack");

        Move(deltaTime);

        Vector3 movemnt = CalculateMovement();

        if (normalizedTime >= attack.AttackEndTimeByAnimation)
        {
            if (isAttack)
            {
                stateMachine.WeaponHendler.DisableWeapon(attack.AttackDamageCount);
                isAttack = false;
            }
        }
        else if (normalizedTime >= attack.AttackTimeByAnimation)
        {
            if (!isAttack)
            {
                stateMachine.WeaponHendler.EnableWeapon(attack.AttackDamageCount);
                isAttack = true;
            }
        }

        if (normalizedTime >= attack.AudioTime && !isAudio)
        {
            stateMachine.AudioLogic.PlayAudio("SwingSword");
            isAudio = true;
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
                TrylightComboAttack(normalizedTime);
            }

            if (stateMachine.InputReader.IsHeavyAttacking)
            {
                TryHeavyComboAttack(normalizedTime);
            }
        }

        if (normalizedTime < attack.PreCancelTime || normalizedTime > attack.PostCancelTime)
        {
            if (!stateMachine.canCancel)
            {
                stateMachine.SetCanCancel(true);
            }
        }
        else
        {
            if (stateMachine.canCancel)
            {
                stateMachine.SetCanCancel(false);
            }

            return;
        }

        if (nextAttack != -1)
        {
            ComboAttack();
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
        stateMachine.SetCanCancel(true);
        stateMachine.WeaponHendler.DisableWeapon(0);
    }

    /// <summary>
    /// 嘗試輕攻擊
    /// </summary>
    private void TrylightComboAttack(float normalizedTime)
    {
        if (attack.lightComboStateIndex == -1)
            return;

        if (normalizedTime < attack.MinComboAttackTime || normalizedTime > attack.MaxComboAttackTime)
            return;

        nextAttack = attack.lightComboStateIndex;
    }

    /// <summary>
    /// 嘗試重攻擊
    /// </summary>
    private void TryHeavyComboAttack(float normalizedTime)
    {
        if (attack.HeavyComboStateIndex == -1)
            return;

        if (normalizedTime < attack.MinComboAttackTime || normalizedTime > attack.MaxComboAttackTime)
            return;

        nextAttack = attack.HeavyComboStateIndex;
    }

    private void ComboAttack()
    {
        stateMachine.SwitchState(new PlayerAttackState(stateMachine, nextAttack));
    }

}
