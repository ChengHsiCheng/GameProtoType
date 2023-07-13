using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01TongueSkillState : Boss01BaseState
{
    private readonly int TongueSkillHash = Animator.StringToHash("TongueSkill");
    private const float CrossFadeDuration = 0.1f;

    bool isUesSkill;
    float timer;

    EnemySkill skill;

    public Boss01TongueSkillState(Boss01StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(TongueSkillHash, CrossFadeDuration);

        skill = stateMachine.Skills[1];
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Skill");

        if (normalizedTime > 0.5f && !isUesSkill)
        {
            GameObject.Instantiate(skill.skill, skill.spawnPoint.position, stateMachine.transform.rotation);

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
    }
}
