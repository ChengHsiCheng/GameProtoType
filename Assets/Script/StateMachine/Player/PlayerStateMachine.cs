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
    [field: SerializeField] public PlayerInfo Info { get; private set; }
    [field: SerializeField] public PlayerUIManager UIManager { get; private set; }
    [field: SerializeField] public WeaponDamage Weapon { get; private set; }
    [field: SerializeField] public SanCheck SanCheck { get; private set; }
    [field: SerializeField] public Attack[] Attacks { get; private set; }
    [field: SerializeField] public PlayerSkill[] Skills { get; private set; }

    [field: SerializeField] public float moveSpeed { get; private set; }
    [field: SerializeField] public float moveSmooth { get; private set; } // 移動加速度起始值
    [field: SerializeField] public float rollSpeed { get; private set; }
    [field: SerializeField] public float RotationDamping { get; private set; }

    public bool canAction { get; private set; } = true;
    [field: SerializeField] public bool canCancel { get; private set; } = true;

    private bool isSanCheck;
    public float sanScalingDamage { get; private set; } = 1;
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
        Info.OnTakeDamage += HandleTakeDamage;
        Info.OnTakeSanDamage += SanTakeDamage;
        Info.OnSanCheck += OnSanCheck;
        Info.OnHpHealing += OnHpHealing;
        Info.OnDie += HandleDie;

        InputReader.TogglePauseEvent += TogglePause;
        InputReader.RollEvent += OnRoll;
        InputReader.SkillEvent += OnSkill;
        InputReader.HealEvent += OnHeal;

        SanCheck.SuccessEvent += SanCheckSuccess;
        SanCheck.FailEvent += SanCheckFail;
    }

    /// <summary>
    /// 被停用時執行
    /// </summary>
    private void OnDisable()
    {
        Info.OnTakeDamage -= HandleTakeDamage;
        Info.OnTakeSanDamage -= SanTakeDamage;
        Info.OnSanCheck -= OnSanCheck;
        Info.OnHpHealing -= OnHpHealing;
        Info.OnDie -= HandleDie;

        InputReader.TogglePauseEvent -= TogglePause;
        InputReader.RollEvent -= OnRoll;
        InputReader.SkillEvent -= OnSkill;
        InputReader.HealEvent -= OnHeal;

        SanCheck.SuccessEvent -= SanCheckSuccess;
        SanCheck.FailEvent -= SanCheckFail;
    }

    public void SetCanAction(bool value)
    {
        canAction = value;
    }

    public void SetCanCancel(bool value)
    {
        canCancel = value;
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
        if (GameManager.isPauseGame)
            return;

        if (!canAction && !canCancel)
            return;

        SwitchState(new PlayerRollState(this));
    }

    private void TogglePause()
    {
        if (isSanCheck)
            return;
        GameManager.TogglePause();
        GameManager.sceneController.SetPauseMeun(GameManager.isPauseGame);
    }

    /// <summary>
    /// 切換到受擊狀態
    /// </summary>
    private void HandleTakeDamage(bool isInpact)
    {
        UpdateUI();

        if (isInpact)
            SwitchState(new PlayerImpactState(this));
    }

    /// <summary>
    /// 切換到受擊狀態
    /// </summary>
    private void SanTakeDamage()
    {
        UpdateUI();

        float sanPercent = Info.san / Info.maxSan;

        switch (sanPercent)
        {
            case 1:
                sanScalingDamage = 1;
                break;
            case > 0.3f:
                sanScalingDamage = 0;
                break;
            default:
                sanScalingDamage = -0.2f;
                break;
        }
    }

    private void OnSanCheck()
    {
        isSanCheck = true;

        UIManager.SetSanCheckBar(true);
        GameManager.TogglePause(true);
    }

    private void SanCheckSuccess()
    {
        isSanCheck = false;

        UIManager.SetSanCheckBar(false);
        GameManager.TogglePause(false);
        Info.SanCheckSuccess();
        UpdateUI();
    }

    private void SanCheckFail()
    {
        isSanCheck = false;

        UIManager.SetSanCheckBar(false);
        GameManager.TogglePause(false);
        HandleDie();
    }

    private void OnHpHealing()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        float healthPercent = Info.health / Info.maxHealth;
        float sanPercent = Info.san / Info.maxSan;

        UIManager.SetHpBar(healthPercent);
        UIManager.SetSanBar(sanPercent);

        GameManager.sceneController.SetVolume(1 - sanPercent);
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

    public override void OnGameTogglePause(bool isPause)
    {
        int intValue = isPause ? 0 : 1; // 把canMove轉成1或0
        Animator.SetFloat("AnimationSpeed", intValue);
    }
}
