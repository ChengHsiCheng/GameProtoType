using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss03IdleState : Boss03BaseState
{
    public Boss03IdleState(Boss03StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime("Idle", 0.1f);
    }

    public override void Tick(float deltaTime)
    {
        EyeFaceTarget(GameManager.player.transform.position, stateMachine.rotationSpeed * deltaTime);

        Whirling(Vector3.one, 1, deltaTime);

        stateMachine.SetCoolDown(Mathf.Max(0, stateMachine.coolDown - deltaTime));

        // 近戰模式計時切換到彈幕模式
        if (!stateMachine.isBarrageState)
        {
            if (stateMachine.meleeStateTimer >= stateMachine.meleeStateMaxTime)
            {
                stateMachine.SetIsBarrageState(true);
                return;
            }
        }

        if (stateMachine.coolDown <= 0)
        {
            if (stateMachine.isFallAttack)
                stateMachine.SwitchState(new Boss03FallAttackState(stateMachine));
            else
                stateMachine.SwitchState(new Boss03ChargeAttackState(stateMachine));

            return;
        }

    }

    public override void Exit()
    {
    }

}
