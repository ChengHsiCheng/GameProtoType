using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;
    protected float moveSmooth = 0.4f;

    private Vector3 lastMovement;

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
        Vector3 movePos = stateMachine.transform.position += ((motion + stateMachine.ForceReceiver.Movement) * deltaTime);

        lastMovement = stateMachine.ForceReceiver.Movement;
        stateMachine.Rigidbody.MovePosition(movePos);
    }

    protected bool DashRayCastHit()
    {
        RaycastHit hit;
        Debug.DrawRay(stateMachine.transform.position, stateMachine.transform.forward, Color.red);
        if (Physics.Raycast(stateMachine.transform.position + (Vector3.up * 0.1f), stateMachine.transform.forward, out hit, 1f))
        {
            return false;
        }
        return true;
    }
}
