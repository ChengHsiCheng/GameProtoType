using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02DieState : Boss02BaseState
{
    public Boss02DieState(Boss02StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime("Die", 0.1f);


        Boss02BelieverStateMachine[] believers = GameObject.FindObjectsOfType<Boss02BelieverStateMachine>();

        foreach (Boss02BelieverStateMachine believer in believers)
        {
            believer.OnDie();
        }

        stateMachine.Tentacles[0].OnDie();
        stateMachine.Tentacles[1].OnDie();

        stateMachine.Altar.OnBossDie();

        GameManager.sceneController.OnClearance();
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {
    }

}
