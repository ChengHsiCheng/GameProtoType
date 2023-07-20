using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public PlayerInfo Health { get; private set; }
    [field: SerializeField] public BarController HpBar { get; private set; }
    [field: SerializeField] public BarController SanBar { get; private set; }
    [field: SerializeField] public WeaponDamage Weapon { get; private set; }
    [field: SerializeField] public Attack[] Attacks { get; private set; }

    [field: SerializeField] public float moveSpeed { get; private set; }
    [field: SerializeField] public float moveSmooth { get; private set; } // 移動加速度起始值
    [field: SerializeField] public float rollSpeed { get; private set; }
    [field: SerializeField] public float RotationDamping { get; private set; }
    [field: SerializeField] public float RollTime { get; private set; } // 躲避時間
    [field: SerializeField] public float RollLength { get; private set; } // 躲避距離
    public Transform MainCameraTransform { get; private set; }

    private void Awake()
    {
        GameManager.player = this.gameObject;
    }

    private void Start()
    {
        SwitchState(new PlayerMovingState(this));

        MainCameraTransform = Camera.main.transform;
    }

    /// <summary>
    /// 被啟用時執行
    /// </summary>
    private void OnEnable()
    {
        Health.OnTakeDamage += HandleTakeDamage;
        Health.OnTakeSanDamage += SanTakeDamage;
        Health.OnDie += HandleDie;
    }

    /// <summary>
    /// 被停用時執行
    /// </summary>
    private void OnDisable()
    {
        Health.OnTakeDamage -= HandleTakeDamage;
        Health.OnTakeSanDamage -= SanTakeDamage;
        Health.OnDie -= HandleDie;
    }

    /// <summary>
    /// 切換到受擊狀態
    /// </summary>
    private void HandleTakeDamage()
    {
        float healthPercent = Health.health / Health.maxHealth;

        HpBar.SetBar(healthPercent);
    }

    /// <summary>
    /// 切換到受擊狀態
    /// </summary>
    private void SanTakeDamage()
    {
        float sanPercent = Health.san / Health.maxSan;

        SanBar.SetBar(sanPercent);
    }

    /// <summary>
    /// 切換到死亡狀態
    /// </summary>
    private void HandleDie()
    {
        // SwitchState(new Boss01DieState(this));
    }

    public override void SetCanMove(bool value) { }
    public override void SetCanMove(bool value, float time) { }
}
