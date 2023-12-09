using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss03StartState : Boss03BaseState
{
    private bool setCamera;
    public Boss03StartState(Boss03StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime("Start", 0.1f);

        stateMachine.AudioLogic.PlayAudio("Start");
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "");

        if (!setCamera && normalizedTime >= -0.01f)
        {
            GameManager.sceneController.cinemachineController.SwitchCamera(CameraMode.BossStart, stateMachine.transform);
            setCamera = true;
        }

        Whirling(Vector3.one, normalizedTime, deltaTime);

        if (normalizedTime >= 1)
        {
            stateMachine.SwitchState(new Boss03IdleState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {
        GameManager.sceneController.cinemachineController.SwitchCamera(CameraMode.Combat);
    }

}
