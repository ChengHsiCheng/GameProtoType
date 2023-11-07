using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss03FallAttackState : Boss03BaseState
{
    private bool isReady;
    private float timer;
    private Vector3 targetPos;

    public Boss03FallAttackState(Boss03StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
    }
    public override void Tick(float deltaTime)
    {
        timer += deltaTime;

        if (!isReady)
        {
            EyeFaceTarget(GameManager.player.transform.position, stateMachine.rotationSpeed);

            targetPos = GameManager.player.transform.position;
            targetPos.y = 10;
            stateMachine.transform.position = Vector3.Lerp(stateMachine.transform.position, targetPos, 3 * deltaTime);

            Whirling(new Vector3(0, 1, 0), 4, deltaTime);

            if (timer > 3)
            {
                isReady = true;
                timer = 0;
            }
            return;
        }

        if (timer < 3)
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
    }

}
