using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss01BaseState : State
{
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
        stateMachine.Controller.Move((motion + stateMachine.ForceReceiver.Movement) * deltaTime);
    }

    /// <summary>
    /// 面對玩家
    /// </summary>
    protected void FacePlayer()
    {
        if (stateMachine.Player == null)
            return;

        Vector3 playerPosition = stateMachine.Player.transform.position;

        Vector3 direction = playerPosition - stateMachine.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

        stateMachine.transform.rotation = Quaternion.RotateTowards(stateMachine.transform.rotation, targetRotation, stateMachine.rotationSpeed * Time.deltaTime);

    }

    protected bool IsInMeleeRange()
    {
        // 計算敵人和玩家之間的距離的平方
        float PlayerDistanceSqr = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;
        // 判斷敵人是否在追蹤範圍內，距離平方是否小於等於攻擊範圍的平方
        return PlayerDistanceSqr <= stateMachine.meleeRange * stateMachine.meleeRange;
    }

    public float GetPlayerAngle()
    {
        Vector3 direction = stateMachine.Player.transform.position - stateMachine.transform.position;
        float angle = Vector3.Angle(stateMachine.transform.forward, direction);
        return angle;
    }

    protected void BackTransitionState()
    {
        stateMachine.SwitchState(new Boss01TransitionState(stateMachine));
    }
}
