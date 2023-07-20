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

    public bool isDead => health <= 0;
    public bool isInvulnerable { get; set; }

    public event Action OnTakeDamage;
    public event Action OnDie;
    public event Action OnTakeSanDamage;

    private void Start()
    {
        health = maxHealth;
        san = maxSan;
    }

    public void SetInvulnerable(bool isInvunerable)
    {
        this.isInvulnerable = isInvunerable;
    }

    public void DealHealthDamage(float damage)
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

        Debug.Log("Hp=" + " " + health);

    }

    public void DealSanDamage(float damage)
    {
        if (san <= 0)
            return;

        if (isInvulnerable)
            return;

        san = Mathf.Max(san - damage, 0);

        OnTakeSanDamage?.Invoke();

        if (san <= 0)
        {
            // sanCheck
        }

        Debug.Log("San=" + " " + san);
    }
}
