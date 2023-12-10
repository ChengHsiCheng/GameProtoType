using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour, Info, Health, San
{
    [field: SerializeField] public float maxHealth { get; private set; }
    public float health { get; private set; }
    [field: SerializeField] public float maxSan { get; private set; }
    public float san { get; private set; }
    private float timer;
    private float invulnerableTime;
    private float sanRecoveryTimer;
    [SerializeField] private float sanRecoverySpeed;
    [SerializeField] private float sanRecoveryTime;

    public bool isDead => health <= 0;
    public bool isInvulnerable { get; set; }
    [SerializeField] private bool Invulnerable;

    public event Action OnTakeDamage;
    public event Action OnDie;
    public event Action OnUpdateSan;
    public event Action OnUpdateUI;
    public event Action OnImpact;

    private void Start()
    {
        health = maxHealth;
        san = maxSan;
    }

    private void Update()
    {
        if (GameManager.isPauseGame)
            return;

        sanRecoveryTimer += Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.T))
        {
            DealSanDamage(6);
        }

        if (sanRecoveryTimer >= sanRecoveryTime && san > 0)
        {
            SanHealing(sanRecoverySpeed * Time.deltaTime);
        }

        if (isInvulnerable == false || invulnerableTime == 0)
            return;

        timer += Time.deltaTime;

        if (timer >= invulnerableTime)
        {
            isInvulnerable = false;
            invulnerableTime = 0;
        }
    }

    public void SetInvulnerable(bool isInvunerable, float time)
    {
        invulnerableTime = time;
        SetInvulnerable(isInvunerable);
    }

    public void SetInvulnerable(bool isInvunerable)
    {
        this.isInvulnerable = isInvunerable;
    }

    public void DealHealthDamage(float damage, bool isImpact)
    {
        if (health <= 0)
            return;

        if (Invulnerable)
            return;

        if (isInvulnerable)
            return;

        health = Mathf.Max(health - damage, 0);
        OnTakeDamage?.Invoke();

        if (health <= 0)
        {
            OnDie?.Invoke();
        }

        if (isImpact && health > 0)
        {
            OnImpact?.Invoke();
        }
    }

    public void Healing(float value)
    {
        health = Mathf.Min(health + value, maxHealth);
        OnUpdateUI?.Invoke();
    }

    public void DealSanDamage(float damage)
    {
        if (san <= 0)
            return;

        if (Invulnerable)
            return;

        if (isInvulnerable)
            return;

        float sanPercentage = san / maxSan;
        float reducedDamagePercentage;

        if (sanPercentage <= 0.3f && sanPercentage > 0.1f)
        {
            reducedDamagePercentage = sanPercentage;
        }
        else if (sanPercentage <= 0.1f)
        {
            reducedDamagePercentage = 0.1f;
        }
        else
        {
            reducedDamagePercentage = 1f;
        }

        // 計算實際傷害
        float finalDamage = damage * reducedDamagePercentage;

        Debug.Log(finalDamage);

        sanRecoveryTimer = 0;

        san = Mathf.Max(san - finalDamage, 0);

        OnUpdateSan?.Invoke();

        if (san <= 0)
        {
            DealHealthDamage(1000, false);
        }
    }

    public void SanHealing(float value)
    {
        san = Mathf.Min(san + value, maxSan);
        OnUpdateSan?.Invoke();
        OnUpdateUI?.Invoke();
    }
    public void SanCheckSuccess()
    {
        maxHealth = 1;
        health = 1;
    }
}
