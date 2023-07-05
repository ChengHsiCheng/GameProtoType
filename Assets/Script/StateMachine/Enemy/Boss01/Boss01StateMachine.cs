using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss01StateMachine : StateMachine
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public EnemyAttack[] Attacks { get; private set; }

    [field: SerializeField] public float movementSpeed { get; private set; }
    [field: SerializeField] public float rotationSpeed { get; private set; }
    [field: SerializeField] public float meleeRange { get; private set; } // 近戰攻擊範圍

    public float cooldownTime;

    public GameObject Player { get; private set; }

    private void Start()
    {
        GameManager gameManager = GameManager.GetInstance();
        Player = gameManager.GetPlayer();

        Agent.updatePosition = false; // 不更新導航代理的位置
        Agent.updateRotation = false; // 不更新導航代理的旋轉

        SwitchState(new Boss01TransitionState(this));
    }

    // 在場景中以紅色繪製出敵人的追擊範圍
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, meleeRange);
    }
}
