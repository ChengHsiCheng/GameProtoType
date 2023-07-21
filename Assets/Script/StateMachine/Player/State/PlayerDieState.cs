using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState : PlayerBaseState
{
    private readonly int DieHash = Animator.StringToHash("Die");
    private const float CrossFadeDuration = 0.1f;


    public PlayerDieState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(DieHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        // DieEvent
    }

    public override void Exit()
    {
    }

}
