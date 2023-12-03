using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss02BelieverStateMachine : StateMachine, Enemy
{
    public event Action<Boss02BelieverStateMachine> OnSacrificeEvent;
    public event Action<Boss02BelieverStateMachine> OnDieEvent;

    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public Collider Collider { get; private set; }
    [field: SerializeField] public EnemyInfo Info { get; private set; }
    [field: SerializeField] public WeaponHendler WeaponHendler { get; private set; }
    [field: SerializeField] public EnemySkill[] Skills { get; private set; }
    [field: SerializeField] public EnemyAttack[] Attacks { get; private set; }
    [field: SerializeField] public WeaponDamage[] WeaponDamages { get; private set; }
    [field: SerializeField] public List<ObjectEntry> VFXList { get; private set; } = new List<ObjectEntry>();
    [field: SerializeField] public List<ObjectEntry> VFXPosList { get; private set; } = new List<ObjectEntry>();

    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject staff;
    [field: SerializeField] public GameObject soul { get; private set; }

    [field: SerializeField] public bool isMelee { get; private set; }
    [field: SerializeField] public float attackRange { get; private set; }
    [field: SerializeField] public float meleeAttackRange { get; private set; }
    [field: SerializeField] public float remotelyAttackRange { get; private set; }
    [field: SerializeField] public float rotateSpeed { get; private set; }
    [field: SerializeField] public float movementSpeed { get; private set; }
    [field: SerializeField] public float attackCoolDown { get; private set; }

    public GameObject Player { get; private set; }
    public bool isDied { get; private set; }

    private void Start()
    {
        GameManager.enemys.Add(this);
        Player = GameManager.player;

        Agent.updatePosition = false; // 不更新導航代理的位置
        Agent.updateRotation = false; // 不更新導航代理的旋轉

        attackCoolDown = UnityEngine.Random.Range(0f, 5f);

        Info.OnTakeDamage += TackDamage;
        Info.OnDie += OnDie;
        WeaponHendler.VFXEvent += OnPlayVFX;

        if (isMelee)
        {
            sword.SetActive(true);
            attackRange = meleeAttackRange;
        }
        else
        {
            staff.SetActive(true);
            attackRange = remotelyAttackRange;
        }

        SwitchState(new Boss02BelieverTransitionState(this));
    }

    private void OnDisable()
    {
        Info.OnTakeDamage -= TackDamage;
        Info.OnDie -= OnDie;
        WeaponHendler.VFXEvent -= OnPlayVFX;

        GameManager.enemys.Remove(this);
    }

    private void TackDamage()
    {
        SwitchState(new Boss02BeloeverImpactState(this));
    }

    public void OnFaint()
    {
        SwitchState(new Boss02BeloeverFaintState(this));
    }


    public void DisFaint()
    {
        SwitchState(new Boss02BelieverTransitionState(this));
    }

    private void OnDie()
    {
        OnDieEvent?.Invoke(this);

        SwitchState(new Boss02BelieverDieState(this));
    }

    public void SetisDied(bool value)
    {
        isDied = value;
    }

    public void SetCoolDown(float time)
    {
        attackCoolDown = time;
    }

    public void BePetrify()
    {
        SetCanMove(false, 3f);

        Material.material.SetFloat("_Petrifaction", 0);
    }

    public void OnPlayVFX(string name)
    {
        Instantiate(GetVFXByName(name), GetVFXPosByName(name));
    }

    public VFXLiveTime PlayVFX(string name)
    {
        return Instantiate(GetVFXByName(name), GetVFXPosByName(name)).GetComponent<VFXLiveTime>();
    }

    // 使用名稱查找對應的物件
    public GameObject GetVFXByName(string objectName)
    {
        ObjectEntry entry = VFXList.Find(e => e.name == objectName);
        if (entry.gameObject != null)
        {
            return entry.gameObject;
        }
        else
        {
            Debug.LogWarning("找不到名為 " + objectName + " 的物件。");
            return null;
        }
    }

    // 使用名稱查找對應的位置
    public Transform GetVFXPosByName(string objectName)
    {
        ObjectEntry entry = VFXPosList.Find(e => e.name == objectName);
        if (entry.gameObject != null)
        {
            return entry.gameObject.transform;
        }
        else
        {
            Debug.LogWarning("找不到名為 " + objectName + " 的物件。");
            return null;
        }
    }


    // 在場景中以紅色繪製出敵人的追擊範圍
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
