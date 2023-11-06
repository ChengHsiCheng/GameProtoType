using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss03FallAttackState : Boss03BaseState
{

    public Boss03FallAttackState(Boss03StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
    }
    public override void Tick(float deltaTime)
    {
        EyeFaceTarget(GameManager.player.transform.position, stateMachine.rotationSpeed);

        Whirling(new Vector3(1, 0, 0), 2, deltaTime);

        if (stateMachine.isBarrageState)
        {
            stateMachine.SwitchState(new Boss03IdleState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {
    }

}
