using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02FaintState : Boss02BaseState
{
    private float timer;
    private bool RepairShield;

    public Boss02FaintState(Boss02StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime("Faint", 0.1f);
    }

    public override void Tick(float deltaTime)
    {
        timer += deltaTime;

        if (timer >= 3 && !RepairShield)
        {
            stateMachine.Animator.CrossFadeInFixedTime("RepairShield", 0.1f);
            RepairShield = true;
            return;
        }

        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "");

        if (normalizedTime >= 1)
        {
            stateMachine.SwitchState(new Boss02IdleState(stateMachine));
            return;
        }

    }

    public override void Exit()
    {
        stateMachine.Altar.ShieldRepair();
    }

}
