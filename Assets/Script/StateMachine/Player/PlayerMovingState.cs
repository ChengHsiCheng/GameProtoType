using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingState : PlayerBaseState
{
    private readonly int MoveSpeedString = Animator.StringToHash("MoveSpeed");
    private readonly int MovingBlendTreeHash = Animator.StringToHash("MovingBlendTree");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;

    private float _moveSmooth;

    public PlayerMovingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.InputReader.RollEvent += OnRoll;

        stateMachine.Animator.CrossFadeInFixedTime(MovingBlendTreeHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.InputReader.IsAttacking)
        {
            stateMachine.SwitchState(new PlayerAttackState(stateMachine, 0));

            return;
        }

        Vector3 movemnt = CalculateMovement();

        Move(movemnt * stateMachine.moveSpeed, deltaTime);

        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            stateMachine.Animator.SetFloat(MoveSpeedString, 0, AnimatorDampTime, deltaTime);
            return;
        }
        stateMachine.Animator.SetFloat(MoveSpeedString, 1, AnimatorDampTime, deltaTime);

        FaceMovementDirection(movemnt, deltaTime);
    }

    public override void Exit()
    {
        stateMachine.InputReader.RollEvent -= OnRoll;
    }

    void OnRoll()
    {
        stateMachine.SwitchState(new PlayerRollState(stateMachine));
    }

    private void FaceMovementDirection(Vector3 movemnt, float deltaTime)
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

}
