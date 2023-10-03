using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss02BelieverBaseState : State
{
    protected Boss02BelieverStateMachine stateMachine;

    public Boss02BelieverBaseState(Boss02BelieverStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    private Vector3 lastMovement;


    /// <summary>
    /// 移動(有水平位移)
    /// </summary>
    protected void Move(Vector3 motion, float deltaTime)
    {

        lastMovement = stateMachine.ForceReceiver.Movement;

        stateMachine.Controller.Move((motion + lastMovement) * deltaTime);
    }

    /// <summary>
    /// 往玩家移動
    /// </summary>
    protected void MoveToTarget(Vector3 targetPos, float movementSpeed, float deltaTime)
    {
        if (stateMachine.Agent.isOnNavMesh)
        {
            stateMachine.Agent.destination = targetPos;

            // 根據導航代理的期望速度移動敵人
            Move(stateMachine.Agent.desiredVelocity.normalized * movementSpeed, deltaTime);
        }

        stateMachine.Agent.nextPosition = stateMachine.transform.position;

        // 將導航代理的速度設置為敵人的控制器速度，以使動畫同步
        stateMachine.Agent.velocity = stateMachine.Controller.velocity;
    }
}
