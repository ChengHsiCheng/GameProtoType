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
        stateMachine.SetCanAction(true);

        stateMachine.Animator.CrossFadeInFixedTime(MovingBlendTreeHash, CrossFadeDuration);

        _moveSmooth = stateMachine.moveSmooth;
    }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.InputReader.IsAttacking && stateMachine.canAction)
        {
            stateMachine.SwitchState(new PlayerAttackState(stateMachine, 0));

            return;
        }

        Vector3 movemnt = CalculateMovement();

        moveSpeedAdd = CalculateMoveAcceleration(movemnt, deltaTime);

        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            stateMachine.Animator.SetFloat(MoveSpeedString, 0, AnimatorDampTime, deltaTime);
            return;
        }

        stateMachine.Animator.SetFloat(MoveSpeedString, moveSpeedAdd, 0, deltaTime);

        FaceMovementDirection(movemnt, deltaTime);

        Move(movemnt * moveSpeedAdd * stateMachine.moveSpeed, deltaTime);
    }

    public override void Exit()
    {

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
