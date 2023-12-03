using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleStateMachine : StateMachine, Enemy
{
    [field: SerializeField] public WeaponHendler WeaponHendler { get; private set; }
    [field: SerializeField] public EnemyAttack[] Attacks { get; private set; }
    [field: SerializeField] public WeaponDamage[] WeaponDamages { get; private set; }
    [field: SerializeField] public GameObject WarningArea { get; private set; }

    [field: SerializeField] public float rotateSpeed { get; private set; }
    [field: SerializeField] public float attackCoolDown { get; private set; }

    public GameObject Player { get; private set; }

    private void Start()
    {
        GameManager.enemys.Add(this);
        Player = GameManager.player;

        SwitchState(new TentacleIdleState(this));
    }

    private void OnDisable()
    {
        GameManager.enemys.Remove(this);
    }

    public void SetCoolDown(float coolDown)
    {
        attackCoolDown = coolDown;
    }

    public void BePetrify()
    {
        SetCanMove(false, 3f);

        Material.material.SetFloat("_Petrifaction", 0);
    }
}
