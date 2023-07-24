using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;
    protected float moveSmooth = 0.4f;

    private Vector3 lastMovement;

    protected bool canAction => stateMachine.canAction;


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

    protected bool MoveRayCastHit()
    {
        RaycastHit hit;
        LayerMask layerMaskToCheck = LayerMask.GetMask("Default", "Enemy");

        Debug.DrawRay(stateMachine.transform.position, stateMachine.transform.forward, Color.red);
        if (Physics.Raycast(stateMachine.transform.position + (Vector3.up * 0.1f), stateMachine.transform.forward, out hit, 1f, layerMaskToCheck))
        {
            return false;
        }
        return true;
    }

    protected void CheckInput(float normalizedTime, float outNormalizedTime)
    {
        if (normalizedTime >= outNormalizedTime && !canAction)
        {
            stateMachine.SetCanAction(true);
        }

        if (!canAction)
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
