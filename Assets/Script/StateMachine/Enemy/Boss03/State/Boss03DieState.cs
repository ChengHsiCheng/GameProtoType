using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss03DieState : Boss03BaseState
{
    public Boss03DieState(Boss03StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime("Die", 0.1f);
        GameManager.sceneController.OnClearance();

        stateMachine.Collider.enabled = false;

        stateMachine.Eye.GetComponent<Rigidbody>().isKinematic = false;
        stateMachine.Eye.GetComponent<Collider>().enabled = true;
        stateMachine.Animator.enabled = false;
        stateMachine.BigRing.GetComponent<Rigidbody>().isKinematic = false;
        stateMachine.BigRing.GetComponent<Collider>().enabled = true;
        stateMachine.SmallRing.GetComponent<Rigidbody>().isKinematic = false;
        stateMachine.SmallRing.GetComponent<Collider>().enabled = true;

        stateMachine.vfx.Stop();

        stateMachine.AudioLogic.PlayAudio("Die");
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {
    }

}
