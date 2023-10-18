using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01FireStormChargeState : Boss01BaseState
{
    private readonly int FireStormChargeString = Animator.StringToHash("FireStormCharge");
    private const float AnimatorDampTime = 0.1f;

    private VFXLiveTime vfx;

    private float timer;

    public Boss01FireStormChargeState(Boss01StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(FireStormChargeString, AnimatorDampTime);

        stateMachine.beAttack = false;

        vfx = stateMachine.PlayVFX("FireStormChargeVFX");

        stateMachine.AudioLogic.PlayLoopAudio("FireStormCharge");
    }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.beAttack && GetPlayerAngle() <= 30)
        {
            stateMachine.SwitchState(new Boss01StiffState(stateMachine));
            return;
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
        vfx.Stop();
        stateMachine.AudioLogic.StopLoopAudio();
    }

}
