using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01StartState : Boss01BaseState
{
    private readonly int RoarAnimatorString = Animator.StringToHash("Roar");
    private const float AnimatorDampTime = 0.1f;

    private bool isDisCloseUp;
    private bool isCamera;

    public Boss01StartState(Boss01StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(RoarAnimatorString, AnimatorDampTime);
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "");

        if (normalizedTime > 0.1f && !isCamera)
        {
            GameManager.sceneController.cinemachineController.SwitchCamera(CameraMode.BossStart, stateMachine.gameObject.transform);
            isCamera = true;
        }

        if (normalizedTime > 0.8f && !isDisCloseUp)
        {
            GameManager.sceneController.cinemachineController.SwitchCamera(CameraMode.Combat);
            isDisCloseUp = true;
            return;
        }

        if (normalizedTime < 1)
            return;

        stateMachine.SwitchState(new Boss01TransitionState(stateMachine));
    }

    public override void Exit()
    {
    }
}
