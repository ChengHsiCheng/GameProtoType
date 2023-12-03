using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02BelieverTransitionState : Boss02BelieverBaseState
{
    private readonly int MoveSpeedString = Animator.StringToHash("MoveSpeed");
    private readonly int MovingBlendTreeHash = Animator.StringToHash("MovingBlendTree");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;

    public Boss02BelieverTransitionState(Boss02BelieverStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(MovingBlendTreeHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        stateMachine.Animator.SetFloat(MoveSpeedString, 0.5f, AnimatorDampTime, deltaTime);

        stateMachine.SetCoolDown(Mathf.Max(0, stateMachine.attackCoolDown - deltaTime));

        FaceTarget(GameManager.player.transform.position, stateMachine.rotateSpeed);

        if (stateMachine.attackCoolDown > 0 && stateMachine.isMelee)
        {
            stateMachine.SwitchState(new Boss02BeloeverRetreatState(stateMachine));
            return;
        }

        if (!IsInAttackRange())
        {
            stateMachine.SwitchState(new Boss02BelieverChaseState(stateMachine));
            return;
        }

        //切換攻擊State
        if (stateMachine.isMelee)
            stateMachine.SwitchState(new Boss02BelieverAttackState(stateMachine));
        else
            stateMachine.SwitchState(new Boss02BelieverSkillState(stateMachine));
    }

    public override void Exit()
    {
    }
}
