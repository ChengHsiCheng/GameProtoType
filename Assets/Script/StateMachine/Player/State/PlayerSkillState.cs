using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillState : PlayerBaseState
{
    private readonly int MoveSpeedString = Animator.StringToHash("MoveSpeed");
    private readonly int MovingBlendTreeHash = Animator.StringToHash("MovingBlendTree");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;

    private float moveSpeedAdd = 0.5f;
    private float timer;
    private bool isUseSkill;

    PlayerSkill skill;

    public PlayerSkillState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.SetCanCancel(true);
        stateMachine.SetCanAction(false);

        skill = stateMachine.Skills[0];

        stateMachine.Animator.SetTrigger("OnCastLoop");

        if (GetAnimatorState(stateMachine.Animator, "Move"))
        {
            return;
        }

        stateMachine.Animator.CrossFadeInFixedTime(MovingBlendTreeHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        // 技能
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Skill");

        if (normalizedTime >= 0.5f && stateMachine.canCancel)
        {
            stateMachine.SetCanCancel(false);
        }

        if (timer >= skill.ChargeTime && !isUseSkill)
        {
            skill.skill.UseSkill();
            isUseSkill = true;
            stateMachine.Animator.SetTrigger("OnCast");
            stateMachine.Info.DealSanDamage(skill.sanCost);

            stateMachine.SwitchState(new PlayerMovingState(stateMachine));
            //
            return;
        }

        timer += deltaTime;

        // 移動
        Vector3 movemnt = CalculateMovement();

        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            stateMachine.Animator.SetFloat(MoveSpeedString, 0, AnimatorDampTime, deltaTime);
            return;
        }

        stateMachine.Animator.SetFloat(MoveSpeedString, moveSpeedAdd, 0, deltaTime);

        FaceMovementDirection(movemnt, deltaTime);

        Move(movemnt * moveSpeedAdd * stateMachine.moveSpeed, deltaTime);
    }

    public override void Exit()
    {
        stateMachine.SetCanCancel(true);
        stateMachine.SetCanAction(true);
    }
}
