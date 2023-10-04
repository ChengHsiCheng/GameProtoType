using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02BelieverAttackState : Boss02BelieverBaseState
{

    private readonly int AttackHash = Animator.StringToHash("Attack");

    private const float CrossFadeDuration = 0.1f;

    private bool isMove;

    public Boss02BelieverAttackState(Boss02BelieverStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(AttackHash, CrossFadeDuration);
    }


    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Attack");

        Move(deltaTime);

        if (normalizedTime >= 0.33f && !isMove)
        {
            Debug.Log("Move");
            stateMachine.ForceReceiver.AddForce(stateMachine.transform.forward * 5);
            isMove = true;
        }

        if (normalizedTime >= 1)
        {
            stateMachine.SwitchState(new Boss02BelieverTransitionState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {
    }
}
