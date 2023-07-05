using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01AttackState : Boss01BaseState
{
    private float previousFrameTime; // 上一幀的正規化時間
    private EnemyAttack attack; // 攻擊的資訊

    public Boss01AttackState(Boss01StateMachine stateMachine, int attackIndex) : base(stateMachine)
    {
        attack = stateMachine.Attacks[attackIndex];
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(attack.AnimationName, attack.TransitionDuration);
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Attack");

        if (normalizedTime < 1f)
        {
            return;
        }
        UnityEngine.Debug.Log("Switch");
        stateMachine.SwitchState(new Boss01TransitionState(stateMachine));
    }

    public override void Exit()
    {
        stateMachine.cooldownTime = attack.CooldownTime;
    }
}