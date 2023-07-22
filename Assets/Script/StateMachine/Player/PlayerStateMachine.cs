using System;
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
    [field: SerializeField] public PlayerSkill[] Skills { get; private set; }

    [field: SerializeField] public float moveSpeed { get; private set; }
    [field: SerializeField] public float moveSmooth { get; private set; } // 移動加速度起始值
    [field: SerializeField] public float rollSpeed { get; private set; }
    [field: SerializeField] public float RotationDamping { get; private set; }
    [field: SerializeField] public bool canAction { get; private set; }
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
        Health.OnHpHealing += OnHpHealing;
        Health.OnDie += HandleDie;

        InputReader.RollEvent += OnRoll;
        InputReader.SkillEvent += OnSkill;
        InputReader.HealEvent += OnHeal;
    }

    /// <summary>
    /// 被停用時執行
    /// </summary>
    private void OnDisable()
    {
        Health.OnTakeDamage -= HandleTakeDamage;
        Health.OnTakeSanDamage -= SanTakeDamage;
        Health.OnHpHealing -= OnHpHealing;
        Health.OnDie -= HandleDie;

        InputReader.RollEvent += OnRoll;
        InputReader.SkillEvent += OnSkill;
        InputReader.HealEvent += OnHeal;
    }

    public void SetCanAction(bool value)
    {
        canAction = value;
    }

    private void OnHeal()
    {
        if (!canAction)
            return;

        if (currentState is PlayerMovingState)
            return;

        PlayerMovingState movingState = new PlayerMovingState(this);
        SwitchState(movingState);
        movingState.OnDrink();
    }

    private void OnSkill()
    {
        if (!canAction)
            return;

        SwitchState(new PlayerSkillState(this));
    }

    private void OnRoll()
    {
        if (!canAction)
            return;

        SwitchState(new PlayerRollState(this));
    }

    /// <summary>
    /// 切換到受擊狀態
    /// </summary>
    private void HandleTakeDamage()
    {
        UpdateUI();

        SwitchState(new PlayerImpactState(this));
    }

    /// <summary>
    /// 切換到受擊狀態
    /// </summary>
    private void SanTakeDamage()
    {
        UpdateUI();
    }

    private void OnHpHealing()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        float healthPercent = Health.health / Health.maxHealth;
        float sanPercent = Health.san / Health.maxSan;

        HpBar.SetBar(healthPercent);
        SanBar.SetBar(sanPercent);
    }

    /// <summary>
    /// 切換到死亡狀態
    /// </summary>
    private void HandleDie()
    {
        SwitchState(new PlayerDieState(this));
    }

    public override void SetCanMove(bool value) { }
    public override void SetCanMove(bool value, float time) { }

}
