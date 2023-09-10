using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDieState : PlayerBaseState
{
    private readonly int DieHash = Animator.StringToHash("Die");
    private const float CrossFadeDuration = 0.1f;

    private float timer;

    public PlayerDieState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Info.SetInvulnerable(true);
        stateMachine.UIManager.SetDiedUI(true);

        stateMachine.SetCanAction(false);
        stateMachine.SetCanCancel(false);
        stateMachine.Animator.CrossFadeInFixedTime(DieHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        // DieEvent
        timer += deltaTime;

        if (Input.anyKeyDown && timer >= 1)
        {
            GameManager.SwitchScene(GameManager.nowScene);
        }
    }

    public override void Exit()
    {
    }

}
