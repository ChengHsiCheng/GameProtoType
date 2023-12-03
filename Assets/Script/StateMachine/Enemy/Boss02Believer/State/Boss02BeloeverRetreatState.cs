using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02BeloeverRetreatState : Boss02BelieverBaseState
{
    private readonly int MoveSpeedString = Animator.StringToHash("MoveSpeed");
    private readonly int MovingBlendTreeHash = Animator.StringToHash("MovingBlendTree");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;

    public Boss02BeloeverRetreatState(Boss02BelieverStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(MovingBlendTreeHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        Vector3 playerPos = stateMachine.Player.transform.position;

        stateMachine.SetCoolDown(Mathf.Max(0, stateMachine.attackCoolDown - deltaTime));

        FaceTarget(GameManager.player.transform.position, stateMachine.rotateSpeed * 0.5f);

        if (stateMachine.attackCoolDown <= 0)
        {
            stateMachine.SwitchState(new Boss02BelieverTransitionState(stateMachine));
            return;
        }

        if (Vector3.Distance(playerPos, stateMachine.transform.position) >= stateMachine.attackRange + 2)
        {
            stateMachine.Animator.SetFloat(MoveSpeedString, 0.5f, AnimatorDampTime, deltaTime);
            return;
        }

        stateMachine.Animator.SetFloat(MoveSpeedString, 0f, AnimatorDampTime, deltaTime);
        MoveToTarget(stateMachine.transform.position - playerPos, stateMachine.movementSpeed, deltaTime);
    }

    public override void Exit()
    {
    }

}
