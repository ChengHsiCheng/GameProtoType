using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02StartState : Boss02BaseState
{
    private bool setCamera;

    public Boss02StartState(Boss02StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime("Start", 0.1f);
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "");

        if (!setCamera && normalizedTime >= -0.01f)
        {
            GameManager.sceneController.cinemachineController.SwitchCamera(CameraMode.BossStart, stateMachine.CameraTarget.transform);
            setCamera = true;
        }

        if (normalizedTime >= 1)
        {
            stateMachine.SwitchState(new Boss02IdleState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {
        GameManager.sceneController.cinemachineController.SwitchCamera(CameraMode.Combat);
    }
}
