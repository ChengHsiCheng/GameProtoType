using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TentacleBaseState : State
{
    protected TentacleStateMachine stateMachine;

    public TentacleBaseState(TentacleStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
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


