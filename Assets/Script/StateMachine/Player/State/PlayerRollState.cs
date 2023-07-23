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
        stateMachine.SetCanAction(false);

        stateMachine.Animator.CrossFadeInFixedTime(RollHash, CrossFadeDuration);

        stateMachine.Info.SetInvulnerable(true);
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Roll");

        // 判斷是否可以操作

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
    }
}
