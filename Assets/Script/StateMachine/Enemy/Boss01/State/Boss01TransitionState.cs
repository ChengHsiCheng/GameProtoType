using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        int ranVal = Random.Range(0, 100);

        if (IsInMeleeRange())
        {
            if (ranVal <= 50)
            {
                stateMachine.SwitchState(new Boss01IdleState(stateMachine, 1));
                Debug.Log("Idle");
            }
            else
            {
                stateMachine.SwitchState(new Boss01AttackState(stateMachine, 0));
                Debug.Log("Attack");
            }
        }
        else
        {
            stateMachine.SwitchState(new Boss01ChaseState(stateMachine));
        }
    }
}
