using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AttackIndex
{
    ForwardAttack, RotateAttack, BackAttack, JumpAttack
}

public class Boss01TransitionState : Boss01BaseState
{

    public Boss01TransitionState(Boss01StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
    }

    public override void Tick(float deltaTime)
    {
        DetermineAction();
    }

    public override void Exit()
    {
    }

    /// <summary>
    /// 判斷要進入哪個State
    /// </summary>
    private void DetermineAction()
    {
        // int ranVal = Random.Range(0, 100);

        if (stateMachine.cooldownTime > 0)
        {
            stateMachine.SwitchState(new Boss01IdleState(stateMachine, stateMachine.cooldownTime));

            return;
        }

        if (IsInMeleeRange())
        {
            if (GetPlayerAngle() <= 30)
            {
                stateMachine.SwitchState(new Boss01AttackState(stateMachine, ((int)AttackIndex.ForwardAttack)));
            }
            else
            {
                int ranVal = Random.Range(0, 100);

                if (ranVal <= 70)
                {
                    stateMachine.SwitchState(new Boss01RotateState(stateMachine));
                }
                else
                {
                    if (GetPlayerAngle() <= 150)
                    {
                        stateMachine.SwitchState(new Boss01AttackState(stateMachine, ((int)AttackIndex.RotateAttack)));
                    }
                    else
                    {
                        stateMachine.SwitchState(new Boss01AttackState(stateMachine, ((int)AttackIndex.BackAttack)));
                    }
                }
            }
        }
        else
        {
            stateMachine.SwitchState(new Boss01AttackState(stateMachine, ((int)AttackIndex.JumpAttack)));

            // stateMachine.SwitchState(new Boss01ChaseState(stateMachine));
        }
    }
}
