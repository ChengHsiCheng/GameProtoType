using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss02BelieverStateMachine : StateMachine, Enemy
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public EnemyInfo Info { get; private set; }

    [field: SerializeField] public float attackRange { get; private set; }
    [field: SerializeField] public float rotateSpeed { get; private set; }
    [field: SerializeField] public float movementSpeed { get; private set; }
    [field: SerializeField] public float attackCoolDown { get; private set; }

    public GameObject Player { get; private set; }

    private void Start()
    {
        GameManager.enemys.Add(this);
        Player = GameManager.player;

        Agent.updatePosition = false; // 不更新導航代理的位置
        Agent.updateRotation = false; // 不更新導航代理的旋轉

        Info.OnDie += OnDie;

        SwitchState(new Boss02BelieverChaseState(this));
    }

    private void OnDisable()
    {
        Info.OnDie -= OnDie;
    }

    private void OnDie()
    {
        Destroy(gameObject);
    }

    public void BePetrify()
    {
    }

    public override void OnGameTogglePause(bool isPause)
    {
    }

    public override void SetCanMove(bool value)
    {
    }

    public override void SetCanMove(bool value, float time)
    {
    }


    // 在場景中以紅色繪製出敵人的追擊範圍
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
