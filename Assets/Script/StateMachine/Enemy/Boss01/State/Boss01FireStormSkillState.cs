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

        stateMachine.cooldownTime = skill.CooldownTime;
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Skill");

        timer += deltaTime;

        if (GetPlayerAngle() >= 5)
        {
            if (DetectLeftOrRight(stateMachine.Player.transform) > 0)
            {
                stateMachine.Animator.SetFloat("Turn", 1, AnimatorDampTime, deltaTime);
            }

            if (DetectLeftOrRight(stateMachine.Player.transform) < 0)
            {
                stateMachine.Animator.SetFloat("Turn", -1, AnimatorDampTime, deltaTime);
            }

            FacePlayer(stateMachine.rotationSpeed * 0.5f);
        }
        else
        {
            stateMachine.Animator.SetFloat("Turn", 0, AnimatorDampTime, deltaTime);
        }

        if (normalizedTime > 0.2f && !isUesSkill)
        {
            Vector3 insPos = skill.spawnPoint.position;
            insPos.y = 0;

            GameObject.Instantiate(skill.skill, insPos, Quaternion.identity).UseSkill(skill.spawnPoint.gameObject);

            isUesSkill = true;
        }

        if (timer < 3f)
        {
            return;
        }

        BackTransitionState();
    }

    public override void Exit()
    {
        stateMachine.Animator.SetFloat("Turn", 0);
    }

    /// <summary>
    /// 計算目標對於面向的方位
    /// </summary>
    private float DetectLeftOrRight(Transform target)
    {
        Vector3 toTarget = target.position - stateMachine.transform.position;
        Vector3 forward = stateMachine.transform.forward;

        // 計算向量的點積
        return Vector3.Dot(toTarget, forward);
    }

}
