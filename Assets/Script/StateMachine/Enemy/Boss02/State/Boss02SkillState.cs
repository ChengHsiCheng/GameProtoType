using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02SkillState : Boss02BaseState
{
    Skill skill;

    public Boss02SkillState(Boss02StateMachine stateMachine, int skillCount) : base(stateMachine)
    {
        skill = stateMachine.skill[skillCount];
    }

    public override void Enter()
    {
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {
    }

}
