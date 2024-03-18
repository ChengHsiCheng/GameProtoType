using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss03SwitchModeState : Boss03BaseState
{
    private float timer;

    public Boss03SwitchModeState(Boss03StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        timer = 0;

        stateMachine.AudioLogic.PlayAudio("Switch");

        stateMachine.WeaponHendler.DisableWeapon(0);
    }

    public override void Tick(float deltaTime)
    {
        timer += deltaTime;

        Whirling(Vector3.one, 10 * timer, deltaTime);

        if (timer >= 2)
        {
            stateMachine.SwitchState(new Boss03BarrageState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {
        stateMachine.sceneController.SwitchPalace(stateMachine.isBarrageState);
        stateMachine.SwitchBossMdoe();
    }

}
