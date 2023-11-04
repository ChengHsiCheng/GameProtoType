using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss03IdleState : Boss03BaseState
{
    public Boss03IdleState(Boss03StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
    }

    public override void Tick(float deltaTime)
    {
        // Debug.Log("FACE");
        EyeFaceTarget(GameManager.player.transform.position, stateMachine.rotationSpeed);

        stateMachine.BigRing.transform.Rotate(Vector3.one * stateMachine.ringSpeed * deltaTime);
        stateMachine.SmallRing.transform.Rotate(-Vector3.one * stateMachine.ringSpeed * deltaTime);
    }

    public override void Exit()
    {
    }

}
