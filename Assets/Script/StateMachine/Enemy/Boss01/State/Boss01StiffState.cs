using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01StiffState : Boss01BaseState
{
    private readonly int StiffHash = Animator.StringToHash("Stiff");
    private const float CrossFadeDuration = 0.1f;

    private float timer;

    public Boss01StiffState(Boss01StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(StiffHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        if (timer >= 3)
        {
            BackTransitionState();
            return;
        }

        timer += deltaTime;
    }

    public override void Exit()
    {
    }

}
