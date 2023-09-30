using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01ChaseState : Boss01BaseState
{
    private readonly int MoveSpeedString = Animator.StringToHash("MoveSpeed");
    private readonly int MovingBlendTreeHash = Animator.StringToHash("MovingBlendTree");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;

    private bool isFace;

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
            switch (Random.Range(0, 100))
            {
                case < 20:
                    stateMachine.SwitchState(new Boss01AttackState(stateMachine, (int)AttackIndex.ForwardAttack));
                    break;
                case < 50:
                    stateMachine.SwitchState(new Boss01AttackState(stateMachine, (int)AttackIndex.SlapAttack));
                    break;
                case < 75:
                    stateMachine.SwitchState(new Boss01AttackState(stateMachine, (int)AttackIndex.RotateAttack));
                    break;
                case < 90:
                    stateMachine.SwitchState(new Boss01FartSkillState(stateMachine));
                    break;
                case < 100:
                    stateMachine.SwitchState(new Boss01EscapeState(stateMachine));
                    break;
            }
            return;
        }

        FacePlayer(stateMachine.rotationSpeed);

        if (!isFace)
        {
            if (GetPlayerAngle() < 15)
            {
                isFace = true;
            }
            return;
        }

        Vector3 playerPos = stateMachine.Player.transform.position;

        MoveToTarget(playerPos, stateMachine.movementSpeed, deltaTime);

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

        stateMachine.Animator.SetFloat(MoveSpeedString, 0);

    }

}
