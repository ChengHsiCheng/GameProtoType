using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Boss02BelieverSacrificeState : Boss02BelieverBaseState
{
    private readonly int MoveSpeedString = Animator.StringToHash("MoveSpeed");
    private readonly int MovingBlendTreeHash = Animator.StringToHash("MovingBlendTree");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;


    private float timer;
    private float sacrificeTime;

    public Boss02BelieverSacrificeState(Boss02BelieverStateMachine stateMachine, float sacrificeTime) : base(stateMachine)
    {
        this.sacrificeTime = sacrificeTime;
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(MovingBlendTreeHash, CrossFadeDuration);
        stateMachine.Animator.SetFloat(MoveSpeedString, 0, AnimatorDampTime, 0);
    }

    public override void Tick(float deltaTime)
    {
        timer += deltaTime;

        if (timer >= sacrificeTime)
        {
            Debug.Log("AA");
            timer = 0;
            stateMachine.SwitchState(new Boss02BelieverIdleState(stateMachine));
        }
    }

    public override void Exit()
    {
    }

}
