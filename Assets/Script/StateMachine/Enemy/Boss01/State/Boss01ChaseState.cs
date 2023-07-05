using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01ChaseState : Boss01BaseState
{
    private readonly int MoveSpeedString = Animator.StringToHash("MoveSpeed");
    private readonly int MovingBlendTreeHash = Animator.StringToHash("MovingBlendTree");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;

    public Boss01ChaseState(Boss01StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(MovingBlendTreeHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        if (IsInMeleeRange())
        {
            BackTransitionState();
            return;
        }

        FacePlayer();

        MoveToPlayer(deltaTime);

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

    /// <summary>
    /// 往玩家移動
    /// </summary>
    protected void MoveToPlayer(float deltaTime)
    {
        if (stateMachine.Agent.isOnNavMesh)
        {
            stateMachine.Agent.destination = stateMachine.Player.transform.position;

            // 根據導航代理的期望速度移動敵人
            Move(stateMachine.Agent.desiredVelocity.normalized * stateMachine.movementSpeed, deltaTime);
        }

        // 將導航代理的速度設置為敵人的控制器速度，以使動畫同步
        stateMachine.Agent.velocity = stateMachine.Controller.velocity;
    }
}
