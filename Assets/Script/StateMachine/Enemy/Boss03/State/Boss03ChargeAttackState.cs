using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss03ChargeAttackState : Boss03BaseState
{
    private enum Stage
    {
        Up, ToTagetPoint, Charge
    }

    private Stage stage = Stage.Up;
    private Vector3 targetPos;
    private Vector3 salfPos;
    private float timer;

    public Boss03ChargeAttackState(Boss03StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
    }

    public override void Tick(float deltaTime)
    {
        salfPos = stateMachine.transform.position;

        if (stage == Stage.Up)
        {
            Whirling(Vector3.one, 1, deltaTime);

            targetPos = salfPos;
            targetPos.y = 8;
            stateMachine.transform.position = Vector3.Lerp(salfPos, targetPos, 3 * deltaTime);

            if (Vector3.Distance(salfPos, targetPos) <= 1)
            {
                targetPos = stateMachine.sceneController.Points[Random.Range(0, stateMachine.sceneController.Points.Length)];
                stage = Stage.ToTagetPoint;
            }

            return;
        }

        if (stage == Stage.ToTagetPoint)
        {
            Whirling(Vector3.one, 1, deltaTime);

            stateMachine.transform.position = Vector3.Lerp(salfPos, targetPos, 10 * deltaTime);

            if (Vector3.Distance(salfPos, targetPos) <= 1)
            {
                stage = Stage.Charge;
            }
            return;
        }

        if (stage == Stage.Charge)
        {
            timer += deltaTime;

            if (timer < 0.5f)
            {
                targetPos = GameManager.player.transform.position - salfPos;
                EyeFaceTarget(GameManager.player.transform.position, stateMachine.rotationSpeed * deltaTime);
                Whirling(Vector3.one, 1 + timer * 5, deltaTime);
                return;
            }

            if (stateMachine.transform.position.x > 18 || stateMachine.transform.position.x < -18
            || stateMachine.transform.position.z > 18 || stateMachine.transform.position.z < -18)
            {
                stateMachine.SwitchState(new Boss03IdleState(stateMachine));
                return;
            }

            Whirling(Vector3.one, 8, deltaTime);

            targetPos.y = 0;
            targetPos.Normalize();

            stateMachine.transform.position += targetPos * 50 * deltaTime;

            return;
        }
    }

    public override void Exit()
    {
    }


}
