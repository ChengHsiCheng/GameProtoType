using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss01TransitionState : Boss01BaseState
{
    public Boss01TransitionState(Boss01StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
    }

    public override void Tick(float deltaTime)
    {
        DetermineAction();
    }

    public override void Exit()
    {
    }

    /// <summary>
    /// 判斷要進入哪個State
    /// </summary>
    private void DetermineAction()
    {
        // 是否在攻擊冷卻狀態
        if (stateMachine.cooldownTime > 0)
        {
            stateMachine.SwitchState(new Boss01IdleState(stateMachine, stateMachine.cooldownTime));
            return;
        }

        stateMachine.SwitchState(new Boss01EscapeState(stateMachine, stateMachine.Scene.escapePoint));
        return;
        /*

        // 在近距離攻擊範圍內
        if (IsInMeleeRange())
        {
            // 取得玩家方位
            if (GetPlayerAngle() <= 30)
            {
                stateMachine.SwitchState(new Boss01AttackState(stateMachine, (int)AttackIndex.ForwardAttack));
                return;
            }

            if (GetPlayerAngle() <= 150)
            {
                if (Random.Range(0, 100) <= 70)
                {
                    stateMachine.SwitchState(new Boss01RotateState(stateMachine));
                    return;
                }

                stateMachine.SwitchState(new Boss01AttackState(stateMachine, (int)AttackIndex.RotateAttack));
                return;
            }

            if (GetPlayerAngle() > 150)
            {
                if (Random.Range(0, 100) <= 70)
                {
                    stateMachine.SwitchState(new Boss01RotateState(stateMachine));
                    return;
                }

                stateMachine.SwitchState(new Boss01AttackState(stateMachine, (int)AttackIndex.BackAttack));
                return;
            }

        }

        // 在近距離攻擊範圍外
        if (!IsInMeleeRange())
        {
            stateMachine.SwitchState(new Boss01ChaseState(stateMachine));
            // stateMachine.SwitchState(new Boss01AttackState(stateMachine, (int)AttackIndex.ChargeAttack));
        }*/
    }
}
