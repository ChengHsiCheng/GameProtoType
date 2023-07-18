using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01FireStormChargeState : Boss01BaseState
{
    private readonly int FireStormChargeString = Animator.StringToHash("FireStormCharge");
    private const float AnimatorDampTime = 0.1f;

    private float timer;

    public Boss01FireStormChargeState(Boss01StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(FireStormChargeString, AnimatorDampTime);

        stateMachine.beAttack = false;
    }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.beAttack)
        {
            stateMachine.SwitchState(new Boss01StiffState(stateMachine));
        }

        if (!stateMachine.canMove)
            return;

        if (timer >= 3)
        {
            stateMachine.SwitchState(new Boss01FireStormSkillState(stateMachine));

            return;
        }

        timer += deltaTime;
    }

    public override void Exit()
    {
    }

}
