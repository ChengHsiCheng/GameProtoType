using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01ImpactState : Boss01BaseState
{
    public Boss01ImpactState(Boss01StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime("GetHit", 0.1f);
    }
    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "");
        stateMachine.cooldownTime -= deltaTime;

        if (normalizedTime >= 0.6f)
        {
            BackTransitionState();
            return;
        }
    }

    public override void Exit()
    {
    }
}
