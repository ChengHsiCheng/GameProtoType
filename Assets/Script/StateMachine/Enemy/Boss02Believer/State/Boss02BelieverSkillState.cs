using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02BelieverSkillState : Boss02BelieverBaseState
{
    private const float CrossFadeDuration = 0.1f;
    EnemySkill skill;

    private bool isUse;

    public Boss02BelieverSkillState(Boss02BelieverStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        int skillCount = Random.Range(0, stateMachine.Skills.Length);

        skill = stateMachine.Skills[skillCount];

        skill.skill.castTransform = skill.spawnPoint;

        stateMachine.Animator.CrossFadeInFixedTime(skill.AnimationName, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Skill");

        if (!isUse)
        {
            FaceTarget(GameManager.player.transform.position, stateMachine.rotateSpeed);
        }

        if (normalizedTime >= skill.UseTimeByAnimation && !isUse)
        {
            skill.skill.UseSkill();
            isUse = true;
        }

        if (normalizedTime >= 1)
        {
            stateMachine.SwitchState(new Boss02BelieverTransitionState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {
    }
}

