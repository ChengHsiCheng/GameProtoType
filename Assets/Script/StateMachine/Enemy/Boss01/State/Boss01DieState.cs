using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01DieState : Boss01BaseState
{
    private readonly int DieAnimatorString = Animator.StringToHash("Die");
    private const float AnimatorDampTime = 0.1f;


    public Boss01DieState(Boss01StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(DieAnimatorString, AnimatorDampTime);

        stateMachine.Collider.enabled = false;

        // 通關腳本

        GameManager.sceneController.OnClearance();
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {
    }

}
