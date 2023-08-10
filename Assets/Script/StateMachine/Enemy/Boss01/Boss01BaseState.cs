using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Boss01BaseState : State
{
    protected enum AttackIndex
    {
        ForwardAttack, SlapAttack, RotateAttack, BackAttack, ChargeAttack
    }

    protected Boss01StateMachine stateMachine;

    public Boss01BaseState(Boss01StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

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
        stateMachine.Controller.Move(motion * deltaTime); //  + stateMachine.ForceReceiver.Movement
    }

    /// <summary>
    /// 面對玩家
    /// </summary>
    protected void FacePlayer(float rotationSpeed)
    {
        if (stateMachine.Player == null)
            return;

        Vector3 playerPosition = stateMachine.Player.transform.position;

        Vector3 direction = playerPosition - stateMachine.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

        stateMachine.transform.rotation = Quaternion.RotateTowards(stateMachine.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 判斷是否在近距離攻擊範圍內
    /// </summary>
    protected bool IsInMeleeRange()
    {
        // 計算敵人和玩家之間的距離的平方
        float PlayerDistanceSqr = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;
        // 判斷敵人是否在追蹤範圍內，距離平方是否小於等於攻擊範圍的平方
        return PlayerDistanceSqr <= stateMachine.meleeRange * stateMachine.meleeRange;
    }

    /// <summary>
    /// 取得自身面向與玩家的角度
    /// </summary>
    public float GetPlayerAngle()
    {
        Vector3 direction = stateMachine.Player.transform.position - stateMachine.transform.position;
        float angle = Vector3.Angle(stateMachine.transform.forward, direction);
        return angle;
    }

    /// <summary>
    /// 取得自身面向與目標的角度
    /// </summary>
    public float GetTargetAngle(Vector3 targetPos)
    {
        Vector3 direction = targetPos - stateMachine.transform.position;
        float angle = Vector3.Angle(stateMachine.transform.forward, direction);
        return angle;
    }

    /// <summary>
    /// 回到狀態機起點
    /// </summary>
    protected void BackTransitionState()
    {
        stateMachine.SwitchState(new Boss01TransitionState(stateMachine));
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

            Debug.Log("move");
        }

        stateMachine.Agent.nextPosition = stateMachine.transform.position;

        // 將導航代理的速度設置為敵人的控制器速度，以使動畫同步
        stateMachine.Agent.velocity = stateMachine.Controller.velocity;
    }
}
