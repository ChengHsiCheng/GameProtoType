using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class Boss01StateMachine : StateMachine, Enemy
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public Boss01Info Health { get; private set; }
    [field: SerializeField] public SkinnedMeshRenderer Material { get; private set; }
    [field: SerializeField] public BarController Bar { get; private set; }
    [field: SerializeField] public Collider Collider { get; private set; }
    [field: SerializeField] public WeaponHendler WeaponHendler { get; private set; }
    [field: SerializeField] public WeaponDamage[] Weapon { get; private set; }
    [field: SerializeField] public EnemyAttack[] Attacks { get; private set; }
    [field: SerializeField] public EnemySkill[] Skills { get; private set; }
    [field: SerializeField] public List<ObjectEntry> VFXList { get; private set; } = new List<ObjectEntry>();
    [field: SerializeField] public List<ObjectEntry> VFXPosList { get; private set; } = new List<ObjectEntry>();
    public Boss01SceneController Scene { get; private set; }

    public float MoveForce { get; private set; }
    [field: SerializeField] public float escapeSpeed { get; private set; }
    [field: SerializeField] public float movementSpeed { get; private set; }
    [field: SerializeField] public float rotationSpeed { get; private set; }
    [field: SerializeField] public float chargeSpeed { get; private set; }
    [field: SerializeField] public float meleeRange { get; private set; } // 近戰攻擊範圍
    [field: SerializeField] public int Stage { get; private set; } = 0;

    public int nowStage = 0;
    public bool beAttack;
    public float cooldownTime;

    public GameObject Player { get; private set; }

    private void Start()
    {
        GameManager.enemys.Add(this);
        Player = GameManager.player;
        Scene = GameManager.sceneController.GetComponent<Boss01SceneController>();

        Agent.updatePosition = false; // 不更新導航代理的位置
        Agent.updateRotation = false; // 不更新導航代理的旋轉

        SwitchState(new Boss01StartState(this));
    }

    /// <summary>
    /// 被啟用時執行
    /// </summary>
    private void OnEnable()
    {
        Health.OnTakeDamage += HandleTakeDamage;
        Health.OnDie += HandleDie;

        WeaponHendler.MoveEvent += OnAttackMove;
        WeaponHendler.VFXEvent += OnPlayVFX;
    }

    /// <summary>
    /// 被停用時執行
    /// </summary>
    private void OnDisable()
    {
        Health.OnTakeDamage -= HandleTakeDamage;
        Health.OnDie -= HandleDie;

        WeaponHendler.MoveEvent -= OnAttackMove;
        WeaponHendler.VFXEvent -= OnPlayVFX;
    }

    private void OnAttackMove()
    {
        ForceReceiver.AddForce(transform.forward * MoveForce);
    }

    public void SetMoveForce(float value)
    {
        MoveForce = value;
    }

    /// <summary>
    /// 切換到受擊狀態
    /// </summary>
    private void HandleTakeDamage(bool isInpact)
    {
        Animator.SetTrigger("GetHit");

        float healthPercent = Health.health / Health.maxHealth;

        Bar.SetBar(healthPercent);

        CheckStageTransition();

        if (GetPlayerAngle() <= 30)
        {
            beAttack = true;
        }
    }

    /// <summary>
    /// 切換到死亡狀態
    /// </summary>
    private void HandleDie()
    {
        SwitchState(new Boss01DieState(this));
    }

    /// <summary>
    /// 判斷切換狀態
    /// </summary>
    private void CheckStageTransition()
    {
        if (Stage == 2)
            return;

        float healthPercent = Health.health / Health.maxHealth;

        switch (Stage)
        {
            case 0:
                if (healthPercent >= 0.66f)
                {
                    return;
                }
                break;
            case 1:
                if (healthPercent >= 0.33f)
                {
                    return;
                }
                break;
        }

        Stage += 1;
    }

    // 在場景中以紅色繪製出敵人的追擊範圍
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, meleeRange);
    }

    public override void SetCanMove(bool value)
    {
        SetCanMove(value, 0);

        Material.material.SetFloat("_Petrifaction", 1);
    }

    public override void SetCanMove(bool canMove, float freezeTime)
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

    public override void OnGameTogglePause(bool isPause)
    {
        if (!isPause && freezeTime != 0)
        {
            return;
        }


        int intValue = isPause ? 0 : 1; // 把canMove轉成1或0
        Animator.SetFloat("AnimationSpeed", intValue);
    }

    /// <summary>
    /// 取得自身面向與玩家的角度
    /// </summary>
    public float GetPlayerAngle()
    {
        Vector3 direction = Player.transform.position - transform.position;
        float angle = Vector3.Angle(transform.forward, direction);
        return angle;
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
}
