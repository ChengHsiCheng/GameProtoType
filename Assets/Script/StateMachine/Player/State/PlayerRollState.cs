using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollState : PlayerBaseState
{
    private readonly int RollHash = Animator.StringToHash("Roll");
    private const float CrossFadeDuration = 0.1f;

    Vector3 faceDis;

    public PlayerRollState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.SetCanAction(false);

        stateMachine.SetCanCancel(false);

        stateMachine.Animator.CrossFadeInFixedTime(RollHash, CrossFadeDuration);

        stateMachine.Info.SetInvulnerable(true);

        faceDis = CalculateMovement();
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Roll");

        if (normalizedTime <= 0.2)
        {
            FaceMovementDirection(faceDis, deltaTime);
        }

        if (normalizedTime <= 0.4)
        {
            if (!MoveRayCastHit())
                return;

            Move(stateMachine.transform.forward * stateMachine.rollSpeed, deltaTime);
        }

        CheckInput(normalizedTime, 0.6f);


    }

    public override void Exit()
    {
        stateMachine.Info.SetInvulnerable(false);

        stateMachine.SetCanCancel(true);
    }

    /// <summary>
    /// 計算玩家移動向量
    /// </summary>
    private Vector3 CalculateMovement()
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

    /// <summary>
    /// 面向移動方向
    /// </summary>
    private void FaceMovementDirection(Vector3 movemnt, float deltaTime)
    {
        // 使用插值的方式將角色的旋轉逐漸調整為面向移動方向
        stateMachine.transform.rotation = Quaternion.Lerp(
            stateMachine.transform.rotation,
            Quaternion.LookRotation(movemnt),
            deltaTime * stateMachine.RotationDamping * 2);
    }
}
