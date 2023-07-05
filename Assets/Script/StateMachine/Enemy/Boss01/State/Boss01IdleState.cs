using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01IdleState : Boss01BaseState
{
    private readonly int MoveSpeedString = Animator.StringToHash("MoveSpeed");
    private readonly int MovingBlendTreeHash = Animator.StringToHash("MovingBlendTree");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;

    private float transitionTime;
    private float timer;

    public Boss01IdleState(Boss01StateMachine stateMachine, float transitionTime) : base(stateMachine)
    {
        this.transitionTime = transitionTime;
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(MovingBlendTreeHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        timer += deltaTime;

        stateMachine.Animator.SetFloat(MoveSpeedString, 0, AnimatorDampTime, deltaTime);

        if (timer >= transitionTime)
        {
            stateMachine.SwitchState(new Boss01TransitionState(stateMachine));
        }
    }

    public override void Exit()
    {
        stateMachine.cooldownTime = 0;
    }
}
