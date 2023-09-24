using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01TongueSkillState : Boss01BaseState
{
    private readonly int TongueSkillHash = Animator.StringToHash("TongueSkill");
    private const float CrossFadeDuration = 0.1f;

    bool isUesSkill;

    private EnemySkill skill_i;
    private Skill skill;

    public Boss01TongueSkillState(Boss01StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(TongueSkillHash, CrossFadeDuration);

        skill_i = stateMachine.Skills[1];

        stateMachine.cooldownTime = Random.Range(skill_i.MinCooldownTime, skill_i.MaxCooldownTime);

    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Skill");

        if (normalizedTime > 0.33f && !isUesSkill)
        {
            skill = GameObject.Instantiate(skill_i.skill, skill_i.spawnPoint);
            skill.UseSkill();

            isUesSkill = true;
        }

        if (normalizedTime < 1f)
        {
            return;
        }

        BackTransitionState();
    }

    public override void Exit()
    {
        skill.DestroySkill();
    }
}
