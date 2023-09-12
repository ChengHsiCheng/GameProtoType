using System.Diagnostics;
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
        if (stateMachine.Stage != stateMachine.nowStage)
        {
            stateMachine.nowStage += 1;
            stateMachine.SwitchState(new Boss01FireStormChargeState(stateMachine));
            return;
        }

        // 是否在攻擊冷卻狀態
        if (stateMachine.cooldownTime > 0)
        {
            stateMachine.SwitchState(new Boss01IdleState(stateMachine, stateMachine.cooldownTime));
            return;
        }

        // 在近距離攻擊範圍內
        if (IsInMeleeRange())
        {
            // 玩家在前方
            if (GetPlayerAngle() <= 30)
            {
                switch (Random.Range(0, 100))
                {
                    case < 30:
                        stateMachine.SwitchState(new Boss01AttackState(stateMachine, (int)AttackIndex.ForwardAttack));
                        break;
                    case < 60:
                        stateMachine.SwitchState(new Boss01AttackState(stateMachine, (int)AttackIndex.SlapAttack));
                        break;
                    case < 80:
                        stateMachine.SwitchState(new Boss01AttackState(stateMachine, (int)AttackIndex.RotateAttack));
                        break;
                    case < 100:
                        stateMachine.SwitchState(new Boss01EscapeState(stateMachine));
                        break;
                }
                return;
            }

            if (GetPlayerAngle() > 30)
            {
                // 隨機數
                switch (Random.Range(0, 100))
                {
                    case < 30:
                        stateMachine.SwitchState(new Boss01RotateState(stateMachine));
                        break;
                    case < 60:
                        stateMachine.SwitchState(new Boss01EscapeState(stateMachine));
                        break;
                    case < 100:
                        {
                            // 玩家在側邊
                            if (GetPlayerAngle() < 150)
                            {
                                stateMachine.SwitchState(new Boss01AttackState(stateMachine, (int)AttackIndex.RotateAttack));
                            }
                            else
                            {
                                stateMachine.SwitchState(new Boss01AttackState(stateMachine, (int)AttackIndex.BackAttack));
                            }
                            break;
                        }
                }
                return;
            }

        }

        // 在近距離攻擊範圍外
        if (!IsInMeleeRange())
        {
            if (Random.Range(0, 100) < 0)
            {
                stateMachine.SwitchState(new Boss01ChaseState(stateMachine));
                return;
            }
            else
            {
                stateMachine.SwitchState(new Boss01RotateState(stateMachine));
                return;
            }
        }
    }
}
