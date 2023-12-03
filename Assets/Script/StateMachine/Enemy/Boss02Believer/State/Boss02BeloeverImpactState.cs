using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02BeloeverImpactState : Boss02BelieverBaseState
{
    public Boss02BeloeverImpactState(Boss02BelieverStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime("GetHit", 0.1f);
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "");

        if (normalizedTime >= 1)
        {
            stateMachine.SwitchState(new Boss02BelieverTransitionState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {
    }

}
