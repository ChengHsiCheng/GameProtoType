using System.Collections;
using System.Collections.Generic;
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
    [field: SerializeField] public WeaponDamage[] Weapon { get; private set; }
    [field: SerializeField] public EnemyAttack[] Attacks { get; private set; }
    [field: SerializeField] public EnemySkill[] Skills { get; private set; }
    public Boss01SceneController Scene { get; private set; }

    [field: SerializeField] public float escapeSpeed { get; private set; }
    [field: SerializeField] public float movementSpeed { get; private set; }
    [field: SerializeField] public float rotationSpeed { get; private set; }
    [field: SerializeField] public float chargeSpeed { get; private set; }
    [field: SerializeField] public float meleeRange { get; private set; } // 近戰攻擊範圍
    [field: SerializeField] public float jumpAttackMoveSpeed { get; private set; }
    [field: SerializeField] public int Stage { get; private set; } = 0;

    public int nowStage = 0;
    public bool beAttack;
    public float cooldownTime = 3;

    public GameObject Player { get; private set; }

    private void Start()
    {
        GameManager.enemys.Add(this);
        Player = GameManager.player;
        Scene = GameManager.sceneController.GetComponent<Boss01SceneController>();

        Agent.updatePosition = false; // 不更新導航代理的位置
        Agent.updateRotation = false; // 不更新導航代理的旋轉

        SwitchState(new Boss01TransitionState(this));
    }

    /// <summary>
    /// 被啟用時執行
    /// </summary>
    private void OnEnable()
    {
        Health.OnTakeDamage += HandleTakeDamage;
        Health.OnDie += HandleDie;
    }

    /// <summary>
    /// 被停用時執行
    /// </summary>
    private void OnDisable()
    {
        Health.OnTakeDamage -= HandleTakeDamage;
        Health.OnDie -= HandleDie;
    }

    /// <summary>
    /// 切換到受擊狀態
    /// </summary>
    private void HandleTakeDamage(bool isInpact)
    {
        Animator.SetTrigger("GetHit");

        float healthPercent = Health.health / Health.maxHealth;
        Debug.Log(healthPercent);

        Bar.SetBar(healthPercent);

        CheckStageTransition();

        beAttack = true;
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
        // 計算角色面向往右 15 度的向量
        Quaternion rotation = Quaternion.Euler(0, 30, 0);
        Quaternion rotation02 = Quaternion.Euler(0, -30, 0);
        Vector3 direction = rotation * transform.forward * 5;
        Vector3 direction02 = rotation02 * transform.forward * 5;

        // 設定 Gizmos 顏色
        Gizmos.color = Color.red;

        // 繪製線段，起點為角色位置，終點為角色位置 + 計算出的方向向量
        Gizmos.DrawLine(transform.position, transform.position + direction);
        Gizmos.DrawLine(transform.position, transform.position + direction02);
    }

    public override void SetCanMove(bool value)
    {
        SetCanMove(value, 0);

        Material.material.SetFloat("_Petrifaction", 1);

    }

    public override void SetCanMove(bool canMove, float freezeTime)
    {
        this.canMove = canMove;
        this.freezeTime = freezeTime;

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
}
