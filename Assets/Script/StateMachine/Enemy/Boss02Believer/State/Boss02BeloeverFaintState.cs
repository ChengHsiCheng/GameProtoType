using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02BeloeverFaintState : Boss02BelieverBaseState
{
    public Boss02BeloeverFaintState(Boss02BelieverStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime("Faint", 0.1f);
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {
    }

}
