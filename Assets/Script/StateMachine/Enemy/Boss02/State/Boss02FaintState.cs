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

        stateMachine.Tentacles[0].OnFaint();
        stateMachine.Tentacles[1].OnFaint();
    }

    public override void Tick(float deltaTime)
    {
        timer += deltaTime;

        if (timer < 5)
            return;

        if (!RepairShield)
        {
            stateMachine.Animator.CrossFadeInFixedTime("RepairShield", 0.1f);
            RepairShield = true;
            return;
        }

        stateMachine.SwitchState(new Boss02IdleState(stateMachine));
        return;
    }

    public override void Exit()
    {
        stateMachine.Altar.ShieldRepair();

        stateMachine.Tentacles[0].DisFaint();
        stateMachine.Tentacles[1].DisFaint();
    }

}
