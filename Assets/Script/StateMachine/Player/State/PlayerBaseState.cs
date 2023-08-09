using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;
    protected float moveSmooth = 0.4f;

    private Vector3 lastMovement;

    protected bool CanAction => stateMachine.canAction;


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
        if (!MoveRayCastHit())
        {
            return;
        }

        Vector3 movePos = stateMachine.transform.position += (motion + stateMachine.ForceReceiver.Movement) * deltaTime;

        lastMovement = stateMachine.ForceReceiver.Movement;

        stateMachine.Rigidbody.MovePosition(movePos + lastMovement);
    }

    protected bool MoveRayCastHit()
    {
        LayerMask layerMaskToCheck = LayerMask.GetMask("Default", "Enemy");

        Debug.DrawRay(stateMachine.transform.position + Vector3.up, stateMachine.transform.forward, Color.red);
        if (Physics.Raycast(stateMachine.transform.position + (Vector3.up * 1f), stateMachine.transform.forward, out _, 1f, layerMaskToCheck))
        {
            return false;
        }
        return true;
    }

    protected void CheckInput(float normalizedTime, float outNormalizedTime)
    {
        if (normalizedTime >= outNormalizedTime && !CanAction)
        {
            stateMachine.SetCanAction(true);
        }

        if (!CanAction)
            return;

        if (stateMachine.InputReader.MovementValue != Vector2.zero || normalizedTime >= 1f)
        {
            stateMachine.SwitchState(new PlayerMovingState(stateMachine));
            return;
        }

        if (stateMachine.InputReader.IsAttacking)
        {
            stateMachine.SwitchState(new PlayerAttackState(stateMachine, 0));
            return;
        }
    }
}
