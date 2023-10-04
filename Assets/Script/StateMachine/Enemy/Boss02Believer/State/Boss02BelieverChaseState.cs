using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02BelieverChaseState : Boss02BelieverBaseState
{
    private readonly int MoveSpeedString = Animator.StringToHash("MoveSpeed");
    private readonly int MovingBlendTreeHash = Animator.StringToHash("MovingBlendTree");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;

    public Boss02BelieverChaseState(Boss02BelieverStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(MovingBlendTreeHash, CrossFadeDuration);

    }

    public override void Tick(float deltaTime)
    {
        Vector3 playerPos = stateMachine.Player.transform.position;

        if (IsInAttackRange())
        {
            stateMachine.SwitchState(new Boss02BelieverTransitionState(stateMachine));
            return;
        }

        playerPos.y = 0;

        MoveToTarget(playerPos, stateMachine.movementSpeed, deltaTime);

        FaceTarget(playerPos, stateMachine.rotateSpeed);

        stateMachine.Animator.SetFloat(MoveSpeedString, 1, AnimatorDampTime, deltaTime);
    }

    public override void Exit()
    {
        if (stateMachine.Agent.isOnNavMesh)
        {
            // 重置導航路徑
            stateMachine.Agent.ResetPath();
        }

        // 停止導航代理的運動
        stateMachine.Agent.velocity = Vector3.zero;
    }
}
