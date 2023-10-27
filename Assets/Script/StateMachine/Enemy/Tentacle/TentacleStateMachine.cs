using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleStateMachine : StateMachine, Enemy
{
    [field: SerializeField] public EnemyInfo Info { get; private set; }
    [field: SerializeField] public WeaponHendler WeaponHendler { get; private set; }
    [field: SerializeField] public Collider Collider { get; private set; }
    [field: SerializeField] public EnemyAttack[] Attacks { get; private set; }
    [field: SerializeField] public WeaponDamage[] WeaponDamages { get; private set; }

    [field: SerializeField] public float attackRange { get; private set; }
    [field: SerializeField] public float rotateSpeed { get; private set; }
    [field: SerializeField] public float attackCoolDown { get; private set; }

    public GameObject Player { get; private set; }


    private void Start()
    {
        GameManager.enemys.Add(this);
        Player = GameManager.player;

        Info.OnDie += Die;

        SwitchState(new TentacleIdleState(this));
    }

    private void OnDisable()
    {
        GameManager.enemys.Remove(this);
        Info.OnDie -= Die;
    }

    public void SetCoolDown(float coolDown)
    {
        attackCoolDown = coolDown;
    }
    public void Die()
    {
        SwitchState(new TentacleDieState(this));
    }

    public void BePetrify()
    {
        SetCanMove(false, 3f);

        Material.material.SetFloat("_Petrifaction", 0);
    }


    // 在場景中以紅色繪製出敵人的追擊範圍
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
