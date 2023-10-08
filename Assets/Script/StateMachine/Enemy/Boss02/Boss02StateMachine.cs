using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss02StateMachine : StateMachine, Enemy
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public SkinnedMeshRenderer Material { get; private set; }
    [field: SerializeField] public Skill[] Skill { get; private set; }
    [field: SerializeField] public Vector3 MoveCenter { get; private set; }
    [field: SerializeField] public float MaxMoveRadius { get; private set; }
    [field: SerializeField] public float MinMoveRadius { get; private set; }
    [field: SerializeField] public float RototeSpeed { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; }


    [field: SerializeField] public GameObject Altarobj { get; private set; }
    public Health AltarHealth { get; private set; }

    [field: SerializeField] public Crown crown { get; private set; }

    protected PlayerStateMachine player;



    private void Start()
    {
        GameManager.enemys.Add(this);
        player = GameManager.player.GetComponent<PlayerStateMachine>();

        Agent.updatePosition = false; // 不更新導航代理的位置
        Agent.updateRotation = false; // 不更新導航代理的旋轉

        AltarHealth = Instantiate(Altarobj, Vector3.zero, Quaternion.identity).GetComponent<Health>();

        SwitchState(new Boss02StartState(this));

        AltarHealth.OnTakeDamage += TakeDamage;
    }

    private void OnDisable()
    {
        AltarHealth.OnTakeDamage -= TakeDamage;

        GameManager.enemys.Remove(this);
    }

    private void TakeDamage()
    {
        if (!player.haveCrown)
            return;

        Debug.Log("2");
    }

    public override void OnGameTogglePause(bool isPause)
    {
        if (!isPause && freezeTime != 0)
        {
            return;
        }


        int intValue = isPause ? 0 : 1; // 把canMove轉成1或0
        Animator.SetFloat("AnimationSpeed", intValue);
    }

    public override void SetCanMove(bool value)
    {
        SetCanMove(value, 0);

        Material.material.SetFloat("_Petrifaction", 1);
    }

    public override void SetCanMove(bool value, float time)
    {
        this.canMove = canMove;
        this.freezeTime = Time.time + freezeTime;

        int intValue = canMove ? 1 : 0; // 把canMove轉成1或0

        Animator.SetFloat("AnimationSpeed", intValue);
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
        Gizmos.DrawWireSphere(MoveCenter, MaxMoveRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(MoveCenter, MinMoveRadius);
    }
}
