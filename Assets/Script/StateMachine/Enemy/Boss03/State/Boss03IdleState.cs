using System.Collections;
using System.Collections.Generic;
using UnityEditor.Media;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss03IdleState : Boss03BaseState
{
    public Boss03IdleState(Boss03StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime("Idle", 0.1f);
    }

    public override void Tick(float deltaTime)
    {
        EyeFaceTarget(GameManager.player.transform.position, stateMachine.rotationSpeed * deltaTime);

        Debug.Log(MoveRayCastHit());

        Whirling(Vector3.one, 1, deltaTime);

        stateMachine.SetCoolDown(Mathf.Max(0, stateMachine.coolDown - deltaTime));

        // 近戰模式計時切換到彈幕模式
        if (!stateMachine.isBarrageState)
        {
            stateMachine.SetMeleeStateTimer(stateMachine.meleeStateTimer + deltaTime);

            if (stateMachine.meleeStateTimer >= stateMachine.meleeStateMaxTime)
            {
                stateMachine.SetIsBarrageState(true);
            }
        }

        if (stateMachine.coolDown <= 0)
        {
            if (stateMachine.isBarrageState)
            {
                stateMachine.SwitchState(new Boss03BarrageState(stateMachine));
                return;
            }
            else
            {
                // stateMachine.SwitchState(new Boss03FallAttackState(stateMachine));
                stateMachine.SwitchState(new Boss03ChargeAttackState(stateMachine));
                return;
            }
        }

    }

    public override void Exit()
    {
    }

}
