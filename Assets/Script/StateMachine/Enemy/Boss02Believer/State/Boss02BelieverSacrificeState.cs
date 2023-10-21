using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Boss02BelieverSacrificeState : Boss02BelieverBaseState
{
    private readonly int WorshipString = Animator.StringToHash("Worship");
    private readonly int SacrificeString = Animator.StringToHash("Sacrifice");

    private const float CrossFadeDuration = 0.1f;

    private float timer;
    private float sacrificeTime;
    private bool isSacrifice;

    public Boss02BelieverSacrificeState(Boss02BelieverStateMachine stateMachine, float sacrificeTime) : base(stateMachine)
    {
        this.sacrificeTime = sacrificeTime;
        Debug.Log(sacrificeTime);
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(WorshipString, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        timer += deltaTime;

        FaceTarget(new Vector3(0, 0, 0), stateMachine.rotateSpeed);

        if (timer >= sacrificeTime && !isSacrifice)
        {
            stateMachine.OnSacrifice();
            stateMachine.Animator.CrossFadeInFixedTime(SacrificeString, CrossFadeDuration);
            isSacrifice = true;
        }

        if (GetNormalizedTime(stateMachine.Animator, "Sacrifice") >= 1)
        {
            stateMachine.SwitchState(new Boss02BelieverDieState(stateMachine));
            return;
        }

    }

    public override void Exit()
    {
    }

}
