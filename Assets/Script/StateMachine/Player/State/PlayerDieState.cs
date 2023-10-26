using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDieState : PlayerBaseState
{
    private readonly int DieHash = Animator.StringToHash("Die");
    private const float CrossFadeDuration = 0.1f;

    public PlayerDieState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Info.SetInvulnerable(true);
        stateMachine.UIManager.SetDiedUI();

        stateMachine.SetCanAction(false);
        stateMachine.SetCanCancel(false);
        stateMachine.Animator.CrossFadeInFixedTime(DieHash, CrossFadeDuration);

        stateMachine.Collider.enabled = false;
        stateMachine.AudioLogic.PlayAudio("Die");
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {
    }

}
