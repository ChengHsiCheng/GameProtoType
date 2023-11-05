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
    }

    public override void Tick(float deltaTime)
    {
        EyeFaceTarget(GameManager.player.transform.position, stateMachine.rotationSpeed);

        Whirling(Vector3.one, deltaTime);

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

        if (stateMachine.isBarrageState && stateMachine.coolDown <= 0)
        {
            stateMachine.SwitchState(new Boss03BarrageState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {
    }

}
