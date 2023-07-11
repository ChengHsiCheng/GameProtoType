using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovingState : PlayerBaseState
{
    private readonly int MoveSpeedString = Animator.StringToHash("MoveSpeed");
    private readonly int MovingBlendTreeHash = Animator.StringToHash("MovingBlendTree");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;

    private float _moveSmooth;
    private float moveSpeedAdd;

    public PlayerMovingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.InputReader.RollEvent += OnRoll;
        stateMachine.InputReader.SkillEvent += UesSkill;

        stateMachine.Animator.CrossFadeInFixedTime(MovingBlendTreeHash, CrossFadeDuration);

        _moveSmooth = stateMachine.moveSmooth;
    }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.InputReader.IsAttacking)
        {
            stateMachine.SwitchState(new PlayerAttackState(stateMachine, 0));

            return;
        }

        Vector3 movemnt = CalculateMovement();

        moveSpeedAdd = CalculateMoveAcceleration(movemnt, deltaTime);

        Move(movemnt * moveSpeedAdd * stateMachine.moveSpeed, deltaTime);

        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            stateMachine.Animator.SetFloat(MoveSpeedString, 0, AnimatorDampTime, deltaTime);
            return;
        }

        stateMachine.Animator.SetFloat(MoveSpeedString, moveSpeedAdd, 0, deltaTime);

        FaceMovementDirection(movemnt, deltaTime);
    }

    public override void Exit()
    {
        stateMachine.InputReader.RollEvent -= OnRoll;
        stateMachine.InputReader.SkillEvent -= UesSkill;

    }

    void OnRoll()
    {
        stateMachine.SwitchState(new PlayerRollState(stateMachine));
    }

    void UesSkill()
    {
        foreach (StateMachine enemy in GameManager.enemys)
        {
            enemy.SetCanMove(false, 1);
        }
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

    /// <summary>
    /// 計算移動加速度
    /// </summary>
    private float CalculateMoveAcceleration(Vector3 movemnt, float deltaTime)
    {
        if (movemnt == Vector3.zero)
        {
            _moveSmooth = stateMachine.moveSmooth;
            return 0;
        }

        _moveSmooth = Mathf.Min(_moveSmooth + _moveSmooth * deltaTime, 1);

        return _moveSmooth;
    }
}
