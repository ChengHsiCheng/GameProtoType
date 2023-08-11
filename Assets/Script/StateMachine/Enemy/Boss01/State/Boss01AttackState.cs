using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01AttackState : Boss01BaseState
{
    private float previousFrameTime; // 上一幀的正規化時間
    private EnemyAttack attack; // 攻擊的資訊
    private WeaponDamage weapon;
    private bool isMoved;

    public Boss01AttackState(Boss01StateMachine stateMachine, int attackIndex) : base(stateMachine)
    {
        attack = stateMachine.Attacks[attackIndex];
        weapon = stateMachine.Weapon[attackIndex];
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(attack.AnimationName, attack.TransitionDuration);

        weapon.SetAttack(attack.Damage, attack.SanDamage);
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Attack");

        Move(deltaTime);

        AttackMove(normalizedTime);

        if (attack.AnimationName == "ChargeAttack")
        {
            ChargeToTarget(deltaTime);
        }

        if (normalizedTime < 1f)
        {
            return;
        }

        if (attack.AnimationName == "SlapAttack" && Random.Range(0, 100) < 50)
        {
            stateMachine.SwitchState(new Boss01AttackState(stateMachine, (int)AttackIndex.ForwardAttack));
            return;
        }

        BackTransitionState();
    }

    public override void Exit()
    {
        stateMachine.cooldownTime = attack.CooldownTime;

        if (stateMachine.Agent.isOnNavMesh)
        {
            // 重置導航路徑
            stateMachine.Agent.ResetPath();
        }

        // 停止導航代理的運動
        stateMachine.Agent.velocity = Vector3.zero;
    }

    private void AttackMove(float normalizedTime)
    {
        if (attack.AnimationName == "SlapAttack")
        {
            SetSlapAttackMove(normalizedTime);
            return;
        }

        if (!isMoved && normalizedTime > attack.MoveTime)
        {
            stateMachine.ForceReceiver.AddForce(stateMachine.transform.forward * attack.MoveForce);
            isMoved = true;
        }
    }

    private void SetSlapAttackMove(float normalizedTime)
    {
        UnityEngine.Debug.Log("AA");
        if (normalizedTime > 0.76f)
        {
            if (isMoved)
            {
                stateMachine.ForceReceiver.AddForce(stateMachine.transform.forward * attack.MoveForce);
                isMoved = false;
            }
            return;
        }

        if (normalizedTime > 0.53f)
        {
            if (!isMoved)
            {
                stateMachine.ForceReceiver.AddForce(stateMachine.transform.forward * attack.MoveForce);
                isMoved = true;
            }
        }
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
