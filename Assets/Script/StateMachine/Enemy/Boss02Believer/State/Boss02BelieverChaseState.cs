using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02BelieverChaseState : Boss02BelieverBaseState
{
    public Boss02BelieverChaseState(Boss02BelieverStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
    }

    public override void Tick(float deltaTime)
    {
        Vector3 playerPos = stateMachine.Player.transform.position;

        MoveToTarget(playerPos, stateMachine.movementSpeed, deltaTime);
    }

    public override void Exit()
    {
        if (stateMachine.Agent.isOnNavMesh)
        {
            // 重置導航路徑
            stateMachine.Agent.ResetPath();
        }

        // 停止導航代理的運動
        stateMachine.Agent.velocity = Vector3.zero;
    }
}
