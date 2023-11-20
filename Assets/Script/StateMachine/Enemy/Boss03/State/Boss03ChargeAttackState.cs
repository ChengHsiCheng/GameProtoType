using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss03ChargeAttackState : Boss03BaseState
{
    private enum Stage
    {
        Up, ToTagetPoint, Charge
    }

    private Stage stage = Stage.Up;
    private Vector3 targetPos;
    private Vector3 salfPos;
    private float timer;
    private int loopIndex;
    private int index;

    private bool isVFX;

    public Boss03ChargeAttackState(Boss03StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        loopIndex = Random.Range(2, 6);
        stateMachine.weapons[0].SetAttack(15, 15);
    }

    public override void Tick(float deltaTime)
    {
        stateMachine.SetMeleeStateTimer(stateMachine.meleeStateTimer + deltaTime);

        salfPos = stateMachine.transform.position;

        if (stage == Stage.Up)
        {
            Whirling(Vector3.one, 1, deltaTime);

            targetPos = salfPos;
            targetPos.y = 8;
            stateMachine.transform.position = Vector3.Lerp(salfPos, targetPos, 3 * deltaTime);

            if (Vector3.Distance(salfPos, targetPos) <= 1)
            {
                targetPos = stateMachine.sceneController.Points[Random.Range(0, stateMachine.sceneController.Points.Length)];
                stage = Stage.ToTagetPoint;
            }

            return;
        }

        if (stage == Stage.ToTagetPoint)
        {
            Whirling(Vector3.one, 1, deltaTime);

            stateMachine.transform.position = Vector3.Lerp(salfPos, targetPos, 10 * deltaTime);
            EyeFaceTarget(GameManager.player.transform.position, Mathf.Infinity * deltaTime);

            if (Vector3.Distance(salfPos, targetPos) <= 1)
            {
                targetPos = GameManager.player.transform.position - salfPos;
                GameObject.Instantiate(stateMachine.VFXPlayer.GetVFXByName("WarningArea"), stateMachine.transform.position, stateMachine.Eye.transform.rotation * Quaternion.Euler(0, -180, 0));
                stage = Stage.Charge;

                stateMachine.WeaponHendler.EnableWeapon(0);
            }
            return;
        }

        if (stage == Stage.Charge)
        {
            timer += deltaTime;

            if (timer < 0.5f)
            {
                Whirling(Vector3.one, 1 + timer * 5, deltaTime);
                return;
            }

            if (stateMachine.transform.position.x > 18.5f || stateMachine.transform.position.x < -18.5f
            || stateMachine.transform.position.z > 18.5f || stateMachine.transform.position.z < -18.5f)
            {
                // 近戰模式計時切換到彈幕模式
                if (!stateMachine.isBarrageState)
                {
                    if (stateMachine.meleeStateTimer >= stateMachine.meleeStateMaxTime)
                    {
                        stateMachine.SetIsBarrageState(true);
                        return;
                    }
                }

                stateMachine.WeaponHendler.DisableWeapon(0);
                isVFX = false;
                if (index < loopIndex)
                {
                    index++;
                    timer = 0;
                    stage = Stage.Up;
                    return;
                }

                stateMachine.SwitchState(new Boss03IdleState(stateMachine));
                return;
            }

            Whirling(Vector3.one, 8, deltaTime);

            if (!isVFX)
            {
                GameObject.Instantiate(stateMachine.VFXPlayer.GetVFXByName("ChargeAttack"), stateMachine.Eye.transform);
                isVFX = true;
            }

            targetPos.y = 0;
            targetPos.Normalize();

            stateMachine.transform.position += targetPos * 60 * deltaTime;

            return;
        }
    }

    public override void Exit()
    {
        stateMachine.SetCoolDown(1);
        stateMachine.SetFallAttack(true);
    }


}
