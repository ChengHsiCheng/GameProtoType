using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01StartState : Boss01BaseState
{
    private float timer;

    public Boss01StartState(Boss01StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
    }

    public override void Tick(float deltaTime)
    {
        // 開場動作
        timer += deltaTime;

        if (timer < 2)
            return;

        stateMachine.SwitchState(new Boss01TransitionState(stateMachine));
    }

    public override void Exit()
    {
    }
}
