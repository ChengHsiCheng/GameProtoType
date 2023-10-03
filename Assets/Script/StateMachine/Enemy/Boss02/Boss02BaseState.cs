using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Boss02BaseState : State
{
    protected enum SkillCount
    {
        CursedVestmentSkill
    }

    protected Boss02StateMachine stateMachine;

    public Boss02BaseState(Boss02StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

}
