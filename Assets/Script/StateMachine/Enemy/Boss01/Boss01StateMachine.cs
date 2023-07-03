using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01StateMachine : StateMachine
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public Attack[] Attacks { get; private set; }

    [field: SerializeField] public GameObject Player { get; private set; }

    private void Start()
    {
        Player = GameObject.Find("Player");

        SwitchState(new Boss01TransitionState(this, 0f));
    }
}
