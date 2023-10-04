using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02BelieverAttackState : Boss02BelieverBaseState
{
    private const float CrossFadeDuration = 0.1f;

    private EnemyAttack attack;
    private bool isMove;

    public Boss02BelieverAttackState(Boss02BelieverStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        attack = stateMachine.attacks[0];

        stateMachine.Animator.CrossFadeInFixedTime(attack.AnimationName, CrossFadeDuration);
    }


    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Attack");

        Move(deltaTime);

        if (normalizedTime >= attack.MoveTime && !isMove)
        {
            Debug.Log("Move");
            stateMachine.ForceReceiver.AddForce(stateMachine.transform.forward * attack.MoveForce);
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
