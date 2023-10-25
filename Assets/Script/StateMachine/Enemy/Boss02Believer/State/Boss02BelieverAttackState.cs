using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss02BelieverAttackState : Boss02BelieverBaseState
{
    private const float CrossFadeDuration = 0.1f;

    private EnemyAttack Attack;
    private WeaponDamage Weapon;
    private bool isMove;

    public Boss02BelieverAttackState(Boss02BelieverStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        int attackIndex = Random.Range(0, stateMachine.Attacks.Length);

        Attack = stateMachine.Attacks[attackIndex];
        Weapon = stateMachine.WeaponDamages[attackIndex];
        Weapon.SetAttack(Attack.Damage, Attack.Impact, Attack.SanDamage);

        stateMachine.Animator.CrossFadeInFixedTime(Attack.AnimationName, CrossFadeDuration);
    }


    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Attack");

        Move(deltaTime);

        if (normalizedTime < Attack.MoveTime)
        {
            FaceTarget(GameManager.player.transform.position, stateMachine.rotateSpeed);
        }

        if (normalizedTime >= Attack.MoveTime && !isMove)
        {
            Debug.Log("Move");
            stateMachine.ForceReceiver.AddForce(stateMachine.transform.forward * Attack.MoveForce);
            isMove = true;
        }

        if (normalizedTime >= 1)
        {
            stateMachine.SwitchState(new Boss02BelieverTransitionState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {
        stateMachine.SetCoolDown(Random.Range(Attack.MinCooldownTime, Attack.MaxCooldownTime));
    }
}
