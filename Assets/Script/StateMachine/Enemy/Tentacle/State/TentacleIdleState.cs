using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleIdleState : TentacleBaseState
{
    private readonly int IdleString = Animator.StringToHash("Idle");
    private const float CrossFadeDuration = 0.1f;


    public TentacleIdleState(TentacleStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(IdleString, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        stateMachine.SetCoolDown(Mathf.Max(0, stateMachine.attackCoolDown - deltaTime));

        FaceTarget(GameManager.player.transform.position, stateMachine.rotateSpeed);

        if (IsInAttackRange() && stateMachine.attackCoolDown <= 0)
        {
            stateMachine.SwitchState(new TentacleAttackState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {
    }
}
