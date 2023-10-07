using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02StartState : Boss02BaseState
{
    public Boss02StartState(Boss02StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.SwitchState(new Boss02IdleState(stateMachine));
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {
    }
}
