using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01FartSkillState : Boss01BaseState
{
    private readonly int FartSkillString = Animator.StringToHash("FartSkill");
    private const float AnimatorDampTime = 0.1f;

    private bool isSkill;


    public Boss01FartSkillState(Boss01StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(FartSkillString, AnimatorDampTime);
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Skill");

        if (normalizedTime >= 0.33f && !isSkill)
        {
            stateMachine.PlayVFX("FartSkillVFX");
            isSkill = true;
        }

        if (normalizedTime < 1)
            return;

        BackTransitionState();
    }

    public override void Exit()
    {
    }

}
