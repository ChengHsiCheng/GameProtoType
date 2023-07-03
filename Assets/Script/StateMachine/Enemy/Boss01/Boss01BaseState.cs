using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss01BaseState : State
{
    protected Boss01StateMachine stateMachine;

    public Boss01BaseState(Boss01StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
}
