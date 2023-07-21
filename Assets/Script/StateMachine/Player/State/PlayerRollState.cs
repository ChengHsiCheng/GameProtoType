using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollState : PlayerBaseState
{
    private readonly int RollHash = Animator.StringToHash("Roll");
    private const float CrossFadeDuration = 0.1f;

    public PlayerRollState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(RollHash, CrossFadeDuration);

        stateMachine.Health.SetInvulnerable(true);
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Roll");

        // 判斷是否可以操作

        if (normalizedTime <= 0.4)
        {
            if (!DashRayCastHit())
                return;

            Move(stateMachine.transform.forward * stateMachine.rollSpeed, deltaTime);
        }

        if (normalizedTime <= 0.6f)
            return;

        if (stateMachine.InputReader.MovementValue != Vector2.zero || normalizedTime >= 0.9f)
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

    public override void Exit()
    {
        stateMachine.Health.SetInvulnerable(false);
    }
}
