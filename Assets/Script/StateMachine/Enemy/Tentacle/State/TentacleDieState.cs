using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleDieState : TentacleBaseState
{
    private readonly int DieString = Animator.StringToHash("Die");
    private const float CrossFadeDuration = 0.1f;

    public TentacleDieState(TentacleStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(DieString, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        if (GetNormalizedTime(stateMachine.Animator, "Die") >= 1)
        {
            GameObject.Destroy(stateMachine.gameObject);
            return;
        }
    }

    public override void Exit()
    {
    }

}
