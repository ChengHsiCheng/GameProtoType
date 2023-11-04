using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss03StateMachine : StateMachine, Enemy
{
    [field: SerializeField] public GameObject Eye { get; private set; }
    [field: SerializeField] public GameObject BigRing { get; private set; }
    [field: SerializeField] public GameObject SmallRing { get; private set; }

    [field: SerializeField] public float ringSpeed { get; private set; }
    [field: SerializeField] public float rotationSpeed { get; private set; }

    protected PlayerStateMachine player;

    private void Start()
    {
        GameManager.enemys.Add(this);

        SwitchState(new Boss03IdleState(this));
    }

    public void BePetrify()
    {
    }
}
