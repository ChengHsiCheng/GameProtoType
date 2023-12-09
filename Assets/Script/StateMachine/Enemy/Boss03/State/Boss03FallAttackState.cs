using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss03FallAttackState : Boss03BaseState
{
    private Vector3 targetPos;
    private bool isPlayVFX;
    private bool isPlaySFX;

    public Boss03FallAttackState(Boss03StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime("FallAttack", 0.1f);

        stateMachine.weapons[0].SetAttack(20, 25);
        stateMachine.WeaponHendler.EnableWeapon(0);

        stateMachine.SetFallAttack(false);
    }
    public override void Tick(float deltaTime)
    {
        stateMachine.SetMeleeStateTimer(stateMachine.meleeStateTimer + deltaTime);

        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Attack");

        if (normalizedTime > 0.9f)
        {
            if (!isPlaySFX)
            {
                stateMachine.AudioLogic.PlayAudio("FallAttack");
                isPlaySFX = true;
            }
        }

        if (normalizedTime < 0.95f)
        {
            EyeFaceTarget(GameManager.player.transform.position, stateMachine.rotationSpeed * deltaTime);

            targetPos = GameManager.player.transform.position;
            targetPos.y = 8;
            stateMachine.transform.position = Vector3.Lerp(stateMachine.transform.position, targetPos, 3 * deltaTime);

            Whirling(Vector3.one, 4 * (1 - normalizedTime), deltaTime);
            return;
        }

        if (!isPlayVFX && stateMachine.transform.position.y <= 1f)
        {
            Vector3 pos = stateMachine.transform.position;
            pos.y = 0;
            GameObject.Instantiate(stateMachine.VFXPlayer.GetVFXByName("FallAttack"), pos, Quaternion.identity);
            isPlayVFX = true;
        }

        if (stateMachine.transform.position.y <= 0.5f)
        {
            stateMachine.WeaponHendler.DisableWeapon(0);
        }

        if (normalizedTime < 1)
        {
            Whirling(Vector3.one, 0.5f, deltaTime);

            targetPos = stateMachine.transform.position;
            targetPos.y = 0f;
            stateMachine.transform.position = Vector3.Lerp(stateMachine.transform.position, targetPos, 15 * deltaTime);
            return;
        }

        stateMachine.SwitchState(new Boss03IdleState(stateMachine));

    }

    public override void Exit()
    {
        stateMachine.SetCoolDown(Random.Range(3, 6));

        stateMachine.WeaponHendler.DisableWeapon(0);
    }

}
