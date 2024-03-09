using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02SkillState : Boss02BaseState
{
    private EnemySkill skill;
    private bool useSkill;
    private CallBelieversSkill callBelieversSkill;

    public Boss02SkillState(Boss02StateMachine stateMachine, int skillCount) : base(stateMachine)
    {
        skill = stateMachine.Skill[skillCount];
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(skill.AnimationName, 0.1f);
        callBelieversSkill = skill.skill.GetComponent<CallBelieversSkill>();
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Skill");

        if (normalizedTime > skill.UseTimeByAnimation && !useSkill)
        {
            callBelieversSkill.UseSkill();
            useSkill = true;
            stateMachine.SetCanCallBelievers(false);
        }

        if (normalizedTime >= 1)
        {
            stateMachine.SwitchState(new Boss02IdleState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {
        stateMachine.SetCooldDown(skill.MaxCooldownTime);
    }
}
