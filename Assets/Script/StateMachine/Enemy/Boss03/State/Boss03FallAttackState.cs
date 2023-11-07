using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss03FallAttackState : Boss03BaseState
{
    private Vector3 targetPos;

    public Boss03FallAttackState(Boss03StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime("FallAttack", 0.1f);
    }
    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Attack");

        if (normalizedTime < 0.95f)
        {
            EyeFaceTarget(GameManager.player.transform.position, stateMachine.rotationSpeed);

            targetPos = GameManager.player.transform.position;
            targetPos.y = 10;
            stateMachine.transform.position = Vector3.Lerp(stateMachine.transform.position, targetPos, 3 * deltaTime);

            Whirling(Vector3.one, 4 * (1 - normalizedTime), deltaTime);
            return;
        }

        if (normalizedTime < 1)
        {
            Whirling(Vector3.one, 0.5f, deltaTime);

            targetPos = stateMachine.transform.position;
            targetPos.y = 3.5f;
            stateMachine.transform.position = Vector3.Lerp(stateMachine.transform.position, targetPos, 15 * deltaTime);
            return;
        }

        stateMachine.SwitchState(new Boss03IdleState(stateMachine));

    }

    public override void Exit()
    {
        stateMachine.SetCoolDown(3);
    }

}
