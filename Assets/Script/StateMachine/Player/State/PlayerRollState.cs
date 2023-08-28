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

        if (normalizedTime <= 0.2 && stateMachine.InputReader.MovementValue != Vector2.zero)
        {
            FaceMovementDirection(faceDis, deltaTime);
        }

        if (normalizedTime <= 0.4)
        {
            Move(stateMachine.transform.forward * stateMachine.rollSpeed, deltaTime);
        }

        CheckInput(normalizedTime, 0.6f);


    }

    public override void Exit()
    {
        stateMachine.Info.SetInvulnerable(false);

        stateMachine.SetCanCancel(true);
    }
}
