using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpactState : PlayerBaseState
{
    private readonly int ImpactHash = Animator.StringToHash("Impact");
    private const float CrossFadeDuration = 0.1f;

    public PlayerImpactState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.SetCanAction(false);
        stateMachine.WeaponHendler.DisableWeapon();

        stateMachine.Animator.CrossFadeInFixedTime(ImpactHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Impact");

        CheckInput(normalizedTime, 0.9f);

        Move(deltaTime);
    }

    public override void Exit()
    {
    }

}
