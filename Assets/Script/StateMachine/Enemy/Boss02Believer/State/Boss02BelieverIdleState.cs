using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02BelieverIdleState : Boss02BelieverBaseState
{
    private readonly int MoveSpeedString = Animator.StringToHash("MoveSpeed");
    private readonly int MovingBlendTreeHash = Animator.StringToHash("MovingBlendTree");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;

    public Boss02BelieverIdleState(Boss02BelieverStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(MovingBlendTreeHash, CrossFadeDuration);
        stateMachine.Animator.SetFloat(MoveSpeedString, 0, AnimatorDampTime, 0);
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {
    }

}
