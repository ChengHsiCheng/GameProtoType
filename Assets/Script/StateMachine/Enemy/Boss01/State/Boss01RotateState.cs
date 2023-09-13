using System.Diagnostics;
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
        if (GetPlayerAngle() <= 5)
        {
            if (IsInMeleeRange())
            {
                stateMachine.SwitchState(new Boss01AttackState(stateMachine, (int)AttackIndex.ForwardAttack));
            }
            else
            {
                switch (Random.Range(0, 100))
                {
                    case < 40:
                        stateMachine.SwitchState(new Boss01ChargeAttackState(stateMachine, (int)AttackIndex.ChargeAttack));
                        break;
                    case < 70:
                        stateMachine.SwitchState(new Boss01FireBreathSkillState(stateMachine));
                        break;
                    case < 100:
                        stateMachine.SwitchState(new Boss01TongueSkillState(stateMachine));
                        break;
                }
            }

            return;
        }

        stateMachine.Animator.SetFloat(MoveSpeedString, 1, AnimatorDampTime, deltaTime);

        FacePlayer(stateMachine.rotationSpeed);
    }

    public override void Exit()
    {
    }

}
