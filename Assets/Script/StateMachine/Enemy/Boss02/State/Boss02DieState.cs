using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02DieState : Boss02BaseState
{
    public Boss02DieState(Boss02StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime("Die", 0.1f);
    }

    public override void Tick(float deltaTime)
    {
        if (GetNormalizedTime(stateMachine.Animator, "Die") >= 1)
        {
            GameManager.sceneController.OnClearance();
        }
    }

    public override void Exit()
    {
    }

}
