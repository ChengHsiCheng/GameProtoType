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

    public bool isDead => health <= 0;
    public bool isInvulnerable { get; set; }
    [SerializeField] private bool Invulnerable;

    public event Action<bool> OnTakeDamage;
    public event Action OnDie;
    public event Action OnTakeSanDamage;
    public event Action OnHpHealing;
    public event Action OnSanCheck;

    private void Start()
    {
        health = maxHealth;
        san = maxSan;
    }

    private void Update()
    {
        if (GameManager.isPauseGame)
            return;

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

    public void DealHealthDamage(float damage, bool isInpact)
    {
        if (health <= 0)
            return;

        if (Invulnerable)
            return;

        if (isInvulnerable)
            return;

        health = Mathf.Max(health - damage, 0);
        OnTakeDamage?.Invoke(isInpact);

        if (health <= 0)
        {
            OnDie?.Invoke();
        }
    }

    public void Healing(float value)
    {
        health = Mathf.Min(health + value, maxHealth);
        OnHpHealing?.Invoke();
    }

    public void DealSanDamage(float damage)
    {
        if (san <= 0)
            return;

        if (Invulnerable)
            return;

        if (isInvulnerable)
            return;

        san = Mathf.Max(san - damage, 0);

        OnTakeSanDamage?.Invoke();

        if (san <= 0)
        {
            OnSanCheck?.Invoke();
        }
    }

    public void SanCheckSuccess()
    {
        maxHealth = 1;
        health = 1;
    }
}
