using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
    [field: SerializeField] public BookController Book { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public Collider Collider { get; private set; }
    [field: SerializeField] public PlayerInfo Info { get; private set; }
    [field: SerializeField] public PlayerUIManager UIManager { get; private set; }
    [field: SerializeField] public WeaponDamage Weapon { get; private set; }
    [field: SerializeField] public WeaponHendler WeaponHendler { get; private set; }
    [field: SerializeField] public Volume volume { get; private set; }
    [field: SerializeField] public Attack[] Attacks { get; private set; }
    [field: SerializeField] public PlayerSkill[] Skills { get; private set; }
    [field: SerializeField] public List<ObjectEntry> VFXList { get; private set; } = new List<ObjectEntry>();
    [field: SerializeField] public AudioLogic AudioLogic { get; private set; }
    [field: SerializeField] public List<UIManager> UI = new List<UIManager>();

    [SerializeField] private InterfaceController interfaceController;

    [field: SerializeField] public float moveSpeed { get; private set; }
    [field: SerializeField] public float moveSmooth { get; private set; } // 移動加速度起始值
    [field: SerializeField] public float rollSpeed { get; private set; }
    [field: SerializeField] public float RotationDamping { get; private set; }
    [field: SerializeField] public int totalHealCount { get; private set; }
    public int healCount { get; private set; }

    [SerializeField] private AudioSource SanAudio;

    public bool canAction { get; private set; } = true;
    public bool canCancel { get; private set; } = true;

    private float GetVFXTimer;
    private bool isSanCheck;
    public float sanScalingDamage { get; private set; } = 1;
    public Transform MainCameraTransform { get; private set; }

    private void Awake()
    {
        GameManager.player = this.gameObject;

        Cursor.visible = false;
    }

    private void Start()
    {
        SwitchState(new PlayerMovingState(this));

        MainCameraTransform = Camera.main.transform;

        // 註冊事件
        InputReader = GameManager.sceneController.InputReader;

        InputReader.TogglePauseEvent += TogglePause;
        InputReader.InteractionEvent += OnInteraction;

        if (SceneManager.GetActiveScene().name == "GameLobby")
            return;

        Info.OnTakeDamage += HandleTakeDamage;
        Info.OnUpdateSan += UpdateSan;
        Info.OnUpdateUI += UpdateUI;
        Info.OnDie += HandleDie;
        Info.OnImpact += GetImpact;

        InputReader.RollEvent += OnRoll;
        InputReader.HealEvent += OnHeal;

        SetlHealCount(totalHealCount);
    }


    /// <summary>
    /// 被停用時執行
    /// </summary>
    private void OnDisable()
    {
        Info.OnTakeDamage -= HandleTakeDamage;
        Info.OnUpdateSan -= UpdateSan;
        Info.OnUpdateUI -= UpdateUI;
        Info.OnDie -= HandleDie;
        Info.OnImpact -= GetImpact;

        InputReader.TogglePauseEvent -= TogglePause;
        InputReader.InteractionEvent -= OnInteraction;
        InputReader.RollEvent -= OnRoll;
        InputReader.HealEvent -= OnHeal;
    }

    public void SetCanAction(bool value)
    {
        canAction = value;
    }

    public void SetCanCancel(bool value)
    {
        canCancel = value;
    }

    private void OnInteraction()
    {
        if (GameManager.isPauseGame)
            return;

        if (UI.Count != 0)
        {
            GameManager.sceneController.UIController.AddUI(UI[0]);
            return;
        }
    }

    public void OnVictory()
    {
        UIManager.SetVictoryUI();
    }

    private void OnHeal()
    {
        if (!canAction)
            return;

        if (healCount <= 0)
            return;

        SwitchState(new PlayerHealState(this));
    }

    public void SetTotalHealCount(int count)
    {
        totalHealCount = count;
        UIManager.SetHealCountText(healCount, totalHealCount);
    }

    public void SetlHealCount(int count)
    {
        healCount = count;
        UIManager.SetHealCountText(healCount, totalHealCount);
    }

    private void OnRoll()
    {
        if (GameManager.isPauseGame)
            return;

        if (!canCancel)
            return;

        SwitchState(new PlayerRollState(this));
    }

    private void TogglePause()
    {
        if (isSanCheck)
            return;

        interfaceController.OnPauseMenu();
    }

    private void HandleTakeDamage()
    {
        UpdateUI();

        UIManager.BeAttack();

        if (GetVFXTimer + 0.2f < Time.time)
        {
            Instantiate(GetVFXByName("GetHit"), transform.position + Vector3.up, Quaternion.identity);
            GetVFXTimer = Time.time;
        }
    }

    private void GetImpact()
    {
        SwitchState(new PlayerImpactState(this));
    }

    /// <summary>
    /// 切換到受擊狀態
    /// </summary>
    private void UpdateSan()
    {
        UpdateUI();

        float sanPercent = Info.san / Info.maxSan;

        switch (sanPercent)
        {
            case 1:
                sanScalingDamage = 0.5f;
                break;
            case > 0.8f:
                sanScalingDamage = 0.2f;
                break;
            case > 0.3f:
                sanScalingDamage = 0;
                break;
            default:
                sanScalingDamage = -0.2f;
                break;
        }
    }

    private void UpdateUI()
    {
        float healthPercent = Info.health / Info.maxHealth;
        float sanPercent = Info.san / Info.maxSan;

        UIManager.SetHpBar(healthPercent);
        UIManager.SetSanBar(sanPercent);

        if (sanPercent == 1)
            return;

        if (sanPercent >= 0.2f)
        {
            SetVolume(1 - sanPercent * 0.8f);
            SanAudio.volume = 1 - sanPercent * 0.8f;
        }
        else
        {
            SetVolume(1);
            SanAudio.volume = 1;
        }

    }

    /// <summary>
    /// 切換到死亡狀態
    /// </summary>
    private void HandleDie()
    {
        SwitchState(new PlayerDieState(this));
    }

    public void SetVolume(float volume)
    {
        if (!this.volume)
            return;

        this.volume.weight = volume;
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

    public void AddUI(UIManager ui)
    {
        UI.Add(ui);

        UIManager.SetHint(true);
    }

    public void RemoveUI(UIManager ui)
    {
        for (int i = 0; i < UI.Count; i++)
        {
            if (UI[i] == ui)
            {
                UI?.RemoveAt(i);
            }
        }

        if (UI.Count != 0)
            return;

        UIManager.SetHint(false);
    }

    public override void SetCanMove(bool value) { }
    public override void SetCanMove(bool value, float time) { }

    public override void OnGameTogglePause(bool isPause)
    {
        int intValue = isPause ? 0 : 1; // 把canMove轉成1或0
        Animator.SetFloat("AnimationSpeed", intValue);
    }

}
