using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleDieState : TentacleBaseState
{
    public TentacleDieState(TentacleStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime("Die", 0.1f);
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {
    }

}
