using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Boss02IdleState : Boss02BaseState
{

    public Boss02IdleState(Boss02StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime("Idle", 0.1f);
    }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.canCallBelievers)
        {
            stateMachine.SwitchState(new Boss02SkillState(stateMachine, 0));
        }
    }

    public override void Exit()
    {

    }

}
