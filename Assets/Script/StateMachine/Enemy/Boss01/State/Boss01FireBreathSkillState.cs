using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01FireBreathSkillState : Boss01BaseState
{
    private readonly int FireBreathSkillHash = Animator.StringToHash("FireBreathSkill");
    private const float CrossFadeDuration = 0.1f;

    bool isUesSkill;
    float timer;

    EnemySkill skill;

    public Boss01FireBreathSkillState(Boss01StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(FireBreathSkillHash, CrossFadeDuration);

        skill = stateMachine.Skills[0];


    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Skill");

        if (normalizedTime > 0.6f && !isUesSkill)
        {
            GameObject.Instantiate(skill.skill, skill.spawnPoint.position, new Quaternion(0, 0, 180, 0));

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
