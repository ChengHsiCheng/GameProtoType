using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleAttackState : TentacleBaseState
{
    private const float CrossFadeDuration = 0.1f;

    private EnemyAttack Attack;
    private WeaponDamage Weapon;

    public TentacleAttackState(TentacleStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Attack = stateMachine.Attacks[0];
        Weapon = stateMachine.WeaponDamages[0];
        Weapon.SetAttack(Attack.Damage, Attack.Impact, Attack.SanDamage);

        stateMachine.Animator.CrossFadeInFixedTime(Attack.AnimationName, CrossFadeDuration);

        GameObject.Instantiate(stateMachine.WarningArea, stateMachine.transform.position + (Vector3.up * 20), stateMachine.transform.rotation);
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Attack");

        if (normalizedTime >= 1)
        {
            stateMachine.SwitchState(new TentacleIdleState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {
        stateMachine.SetCoolDown(Random.Range(Attack.MinCooldownTime, Attack.MaxCooldownTime));
    }

}
