using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01FireStormSkillState : Boss01BaseState
{
    private readonly int FireStormSkillString = Animator.StringToHash("FireStormSkill");
    private const float AnimatorDampTime = 0.1f;

    bool isUesSkill;
    float timer;

    EnemySkill skill;

    public Boss01FireStormSkillState(Boss01StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(FireStormSkillString, AnimatorDampTime);

        skill = stateMachine.Skills[2];
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Skill");

        if (normalizedTime > 0.2f && !isUesSkill)
        {
            Vector3 insPos = skill.spawnPoint.position;
            insPos.y = 0;

            GameObject.Instantiate(skill.skill, insPos, Quaternion.identity);

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
