using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Boss02BaseState : State
{
    protected enum SkillCount
    {
        CursedVestmentSkill
    }

    protected Boss02StateMachine stateMachine;

    public Boss02BaseState(Boss02StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    /// <summary>
    /// 面對目標
    /// </summary>
    protected void FaceTarget(Vector3 targetPos, float rotationSpeed)
    {
        targetPos.y = stateMachine.transform.position.y;
        Vector3 direction = targetPos - stateMachine.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

        stateMachine.transform.rotation = Quaternion.RotateTowards(stateMachine.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 移動(有水平位移)
    /// </summary>
    protected void Move(Vector3 motion, float deltaTime)
    {
        stateMachine.Controller.Move(motion * deltaTime);
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
}
