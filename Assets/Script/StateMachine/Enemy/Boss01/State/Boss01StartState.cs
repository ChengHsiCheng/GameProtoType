using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01StartState : Boss01BaseState
{
    public Boss01StartState(Boss01StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
    }

    public override void Tick(float deltaTime)
    {
        // 開場動作

        stateMachine.SwitchState(new Boss01TransitionState(stateMachine));
    }

    public override void Exit()
    {
    }
}