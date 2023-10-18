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
    private bool isPlayAnimator;

    PlayerSkill skill;
    VFXLiveTime vfx;

    public PlayerSkillState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.SetCanCancel(true);
        stateMachine.SetCanAction(false);

        skill = stateMachine.Skills[0];

        stateMachine.Animator.SetTrigger("OnCastLoop");
        stateMachine.AudioLogic.PlayLoopAudio("SkillCasting");
        vfx = MonoBehaviour.Instantiate(stateMachine.GetVFXByName("SkillCasting"), stateMachine.Book.transform).GetComponent<VFXLiveTime>();

        if (GetAnimatorState(stateMachine.Animator, "Move"))
        {
            return;
        }

        stateMachine.Animator.CrossFadeInFixedTime(MovingBlendTreeHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        timer += deltaTime;

        if (timer + 1 >= skill.ChargeTime && !isPlayAnimator)
        {
            stateMachine.Book.PlayerAnimation();
            isPlayAnimator = true;
        }

        if (timer >= 0.5f && stateMachine.canCancel)
        {
            stateMachine.SetCanCancel(false);
        }

        if (timer >= skill.ChargeTime && !isUseSkill)
        {
            UseSkill();
            stateMachine.SwitchState(new PlayerMovingState(stateMachine));

            stateMachine.AudioLogic.PlayAudio("SkillCast");

            vfx.Stop();

            switch (skill.name)
            {
                case "PetrochemicalSkill":
                    MonoBehaviour.Instantiate(stateMachine.GetVFXByName("PetrochemicalSkillVFX"), stateMachine.Book.transform);
                    break;
            }

            return;
        }
        Moving(deltaTime);
    }

    public override void Exit()
    {
        stateMachine.SetCanCancel(true);
        stateMachine.SetCanAction(true);

        stateMachine.AudioLogic.StopLoopAudio();

        vfx.Stop();
    }

    private void UseSkill()
    {
        skill.skill.UseSkill();
        isUseSkill = true;
        stateMachine.Animator.SetTrigger("OnCast");
        stateMachine.Info.DealSanDamage(skill.sanCost);
    }

    private void Moving(float deltaTime)
    {
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
}
