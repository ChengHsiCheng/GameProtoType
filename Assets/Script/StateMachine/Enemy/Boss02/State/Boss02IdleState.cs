using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Boss02IdleState : Boss02BaseState
{
    private Vector3 targetPos;

    private float moveTimer;

    public Boss02IdleState(Boss02StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        targetPos = FindRandomPoint();
    }

    public override void Tick(float deltaTime)
    {
        stateMachine.SetCooldDown(stateMachine.CooldDown - deltaTime);

        FaceTarget(GameManager.player.transform.position, stateMachine.RototeSpeed);

        MoveToTarget(targetPos, stateMachine.MoveSpeed, deltaTime);

        // 檢查是否到達目標座標
        if (Vector3.Distance(stateMachine.transform.position, targetPos) <= 0.3f)
        {
            moveTimer += deltaTime;

            if (moveTimer > 1)
                targetPos = FindRandomPoint();
        }


        if (stateMachine.CooldDown <= 0)
        {
            stateMachine.SwitchState(new Boss02SkillState(stateMachine, (int)SkillCount.BloodRitualAltarSkill));
        }
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


    private Vector3 FindRandomPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 50.0f;
        randomDirection += stateMachine.transform.position;

        NavMeshHit hit;

        NavMesh.SamplePosition(randomDirection, out hit, 50.0f, ~3);

        return hit.position;
    }

}
