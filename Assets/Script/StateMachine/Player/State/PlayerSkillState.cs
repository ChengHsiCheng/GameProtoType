using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillState : PlayerBaseState
{
    private readonly int SkillCastLoopHash = Animator.StringToHash("CastLoop");
    private readonly int SkillCastHash = Animator.StringToHash("Cast");
    private const float CrossFadeDuration = 0.1f;
    PlayerSkill skill;

    private float timer;
    private bool isUseSkill;

    public PlayerSkillState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.SetCanCancel(true);
        stateMachine.SetCanAction(false);

        stateMachine.Animator.CrossFadeInFixedTime(SkillCastLoopHash, CrossFadeDuration);

        skill = stateMachine.Skills[0];
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Skill");

        if (normalizedTime >= 0.5f && stateMachine.canCancel)
        {
            stateMachine.SetCanCancel(false);
        }

        if (timer >= skill.ChargeTime && !isUseSkill)
        {
            skill.skill.UseSkill();
            isUseSkill = true;
            stateMachine.Animator.CrossFadeInFixedTime(SkillCastHash, CrossFadeDuration);

            stateMachine.Info.DealSanDamage(skill.sanCost);

            return;
        }

        timer += deltaTime;

        if (isUseSkill)
        {
            CheckInput(normalizedTime, 0.8f);
        }
    }

    public override void Exit()
    {
        stateMachine.SetCanCancel(true);
        stateMachine.SetCanAction(true);
    }

}
