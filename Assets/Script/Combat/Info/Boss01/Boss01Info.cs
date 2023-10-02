using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01Info : MonoBehaviour, Info, Health
{
    [field: SerializeField] public float maxHealth { get; private set; }
    public float health { get; private set; }
    public bool isDead => health <= 0;
    public bool isInvulnerable { get; set; }
    public event Action OnTakeDamage;
    public event Action OnDie;
    public event Action OnUpdateUI;

    private void Start()
    {
        health = maxHealth;

        OnUpdateUI?.Invoke();
    }

    public void SetInvulnerable(bool isInvunerable)
    {
        this.isInvulnerable = isInvunerable;
    }

    public void DealHealthDamage(float damage, bool isImpact)
    {
        if (health <= 0)
            return;

        if (isInvulnerable)
            return;

        health = Mathf.Max(health - damage, 0);

        OnTakeDamage?.Invoke();

        if (health <= 0)
        {
            OnDie?.Invoke();
        }
    }

    public void Healing(float value)
    {
    }
}
