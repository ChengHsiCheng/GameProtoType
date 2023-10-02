using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02CursedVestmentSkillState : Boss02BaseState
{
    private Crown crown;
    public Boss02CursedVestmentSkillState(Boss02StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        crown = GameObject.Instantiate(stateMachine.crown, stateMachine.transform.position, Quaternion.identity);
        crown.SetCrownHolder(GameManager.player);
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {
    }
}
