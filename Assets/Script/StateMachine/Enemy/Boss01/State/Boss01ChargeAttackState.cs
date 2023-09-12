using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01ChargeAttackState : Boss01BaseState
{
    private EnemyAttack attack; // 攻擊的資訊
    private WeaponDamage weapon;
    private float timer;

    public Boss01ChargeAttackState(Boss01StateMachine stateMachine, int attackIndex) : base(stateMachine)
    {
        attack = stateMachine.Attacks[attackIndex];
        weapon = stateMachine.Weapon[attackIndex];
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(attack.AnimationName, attack.TransitionDuration);

        weapon.SetAttack(attack.Damage, attack.SanDamage);

        weapon.SetCollider(true);

        stateMachine.PlayVFX("ChargeSkillVFX");
    }

    public override void Tick(float deltaTime)
    {
        timer += deltaTime;

        if (attack.AnimationName == "ChargeAttack")
        {
            ChargeToTarget(deltaTime);
        }

        if (timer < 1)
            return;

        BackTransitionState();
    }

    public override void Exit()
    {
        Debug.Log(weapon.gameObject);

        stateMachine.cooldownTime = attack.CooldownTime;

        if (stateMachine.Agent.isOnNavMesh)
        {
            // 重置導航路徑
            stateMachine.Agent.ResetPath();
        }

        // 停止導航代理的運動
        stateMachine.Agent.velocity = Vector3.zero;

        weapon.SetCollider(false);

    }

    protected void ChargeToTarget(float deltaTime)
    {
        if (stateMachine.Agent.isOnNavMesh)
        {
            stateMachine.Agent.destination = stateMachine.transform.position + stateMachine.transform.forward;

            // 根據導航代理的期望速度移動敵人
            Move(stateMachine.Agent.desiredVelocity.normalized * stateMachine.chargeSpeed, deltaTime);
        }

        // 將導航代理的速度設置為敵人的控制器速度，以使動畫同步
        stateMachine.Agent.velocity = stateMachine.Controller.velocity;
    }

}
