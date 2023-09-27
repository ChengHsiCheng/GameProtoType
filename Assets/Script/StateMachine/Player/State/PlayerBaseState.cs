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
            motion = Vector3.zero;
        }

        Vector3 movePos = stateMachine.transform.position += (motion + stateMachine.ForceReceiver.Movement) * deltaTime;

        stateMachine.Rigidbody.MovePosition(movePos);
    }

    protected bool MoveRayCastHit()
    {
        LayerMask layerMaskToCheck = LayerMask.GetMask("Default", "Enemy");

        Debug.DrawRay(stateMachine.transform.position + Vector3.up, stateMachine.transform.forward, Color.red);
        if (Physics.Raycast(stateMachine.transform.position + (Vector3.up * 1f), stateMachine.transform.forward, out _, 1f, layerMaskToCheck))
        {
            return false;
        }

        Debug.DrawRay(stateMachine.transform.position + Vector3.up * 0.1f, stateMachine.transform.forward, Color.red);
        if (Physics.Raycast(stateMachine.transform.position + (Vector3.up * 0.1f), stateMachine.transform.forward, out _, 1f, layerMaskToCheck))
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


    /// <summary>
    /// 面向移動方向
    /// </summary>
    protected void FaceMovementDirection(Vector3 movemnt, float deltaTime)
    {
        // 使用插值的方式將角色的旋轉逐漸調整為面向移動方向
        stateMachine.transform.rotation = Quaternion.Lerp(
            stateMachine.transform.rotation,
            Quaternion.LookRotation(movemnt),
            deltaTime * stateMachine.RotationDamping);
    }

    /// <summary>
    /// 計算玩家移動向量
    /// </summary>
    protected Vector3 CalculateMovement()
    {
        Vector3 forward = stateMachine.MainCameraTransform.forward;
        Vector3 right = stateMachine.MainCameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // 根據玩家輸入的移動值和相機的前方與右方向量計算最終的移動向量
        return forward * stateMachine.InputReader.MovementValue.y +
            right * stateMachine.InputReader.MovementValue.x;
    }
}
