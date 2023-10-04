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
    /// 移動(沒有水平位移)
    /// </summary>
    protected void Move(float deltaTime)
    {
        Move(Vector3.zero, deltaTime);
    }

    /// <summary>
    /// 移動(有水平位移)
    /// </summary>
    protected void Move(Vector3 motion, float deltaTime)
    {
        lastMovement = stateMachine.ForceReceiver.Movement;

        stateMachine.Controller.Move((motion + lastMovement) * deltaTime);
    }

    /// <summary>
    /// 往目標移動
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

    /// <summary>
    /// 面對目標
    /// </summary>
    protected void FaceTarget(Vector3 targetPos, float rotationSpeed)
    {
        Vector3 direction = targetPos - stateMachine.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

        stateMachine.transform.rotation = Quaternion.RotateTowards(stateMachine.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 判斷是否在近距離攻擊範圍內
    /// </summary>
    protected bool IsInAttackRange()
    {
        // 計算敵人和玩家之間的距離的平方
        float PlayerDistanceSqr = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;
        // 判斷敵人是否在追蹤範圍內，距離平方是否小於等於攻擊範圍的平方
        return PlayerDistanceSqr <= stateMachine.attackRange * stateMachine.attackRange;
    }
}
