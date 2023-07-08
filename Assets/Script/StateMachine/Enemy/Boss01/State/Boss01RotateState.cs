using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01RotateState : Boss01BaseState
{
    private readonly int MoveSpeedString = Animator.StringToHash("MoveSpeed");
    private readonly int MovingBlendTreeHash = Animator.StringToHash("MovingBlendTree");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;

    public Boss01RotateState(Boss01StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(MovingBlendTreeHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        if (GetPlayerAngle() <= 10)
        {
            if (IsInMeleeRange())
            {
                int r = Random.Range(0, 100);

                if (r <= 50)
                {
                    stateMachine.SwitchState(new Boss01AttackState(stateMachine, (int)AttackIndex.ForwardAttack));
                }
                else
                {
                    // 逃跑狀態
                }
            }
            else
            {
                // 遠程攻擊
            }

            return;
        }

        stateMachine.Animator.SetFloat(MoveSpeedString, 1, AnimatorDampTime, deltaTime);

        FacePlayer();
    }

    public override void Exit()
    {
    }

}
