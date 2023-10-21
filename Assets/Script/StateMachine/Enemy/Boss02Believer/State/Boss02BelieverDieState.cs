using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02BelieverDieState : Boss02BelieverBaseState
{
    private readonly int DieString = Animator.StringToHash("Die");
    private const float CrossFadeDuration = 0.1f;

    public Boss02BelieverDieState(Boss02BelieverStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(DieString, CrossFadeDuration);
        stateMachine.SetisDied(true);
    }

    public override void Tick(float deltaTime)
    {
        if (GetNormalizedTime(stateMachine.Animator, "") >= 1)
        {
            GameObject.Destroy(stateMachine.gameObject);
            return;
        }
    }

    public override void Exit()
    {
    }
}
