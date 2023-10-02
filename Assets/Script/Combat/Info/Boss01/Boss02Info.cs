using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02Info : MonoBehaviour, Info, Health
{
    public bool isInvulnerable { get; set; }

    public bool isDead { get; private set; }

    public float maxHealth { get; private set; }

    public float health { get; private set; }
    public event Action OnDie;
    public event Action OnTakeDamage;
    public event Action OnUpdateUI;

    public void DealHealthDamage(float damage, bool isImpact)
    {
    }

    public void Healing(float value)
    {
    }

    public void SetInvulnerable(bool isInvunerable)
    {
        this.isInvulnerable = isInvunerable;
    }
}
