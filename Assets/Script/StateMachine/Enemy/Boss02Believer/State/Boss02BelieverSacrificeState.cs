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
        Debug.Log(sacrificeTime);
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(MovingBlendTreeHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        timer += deltaTime;

        // Debug.Log(timer);

        stateMachine.Animator.SetFloat(MoveSpeedString, 1, AnimatorDampTime, deltaTime);


        if (timer >= sacrificeTime)
        {
            Debug.Log("AA");
            stateMachine.SwitchState(new Boss02BelieverIdleState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {
    }

}
