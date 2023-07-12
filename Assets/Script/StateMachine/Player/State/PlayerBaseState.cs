using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;
    protected float moveSmooth = 0.4f;

    // 在new時取得stateMachine
    public PlayerBaseState(PlayerStateMachine stateMachine)
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
        // stateMachine.Controller.Move((motion + stateMachine.ForceReceiver.Movement) * deltaTime);
        stateMachine.Rigidbody.MovePosition(stateMachine.transform.position += ((motion + stateMachine.ForceReceiver.Movement) * deltaTime));
    }
}
