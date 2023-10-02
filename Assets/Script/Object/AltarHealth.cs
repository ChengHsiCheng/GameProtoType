using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarHealth : MonoBehaviour, Health
{
    public float maxHealth { get; private set; }
    public float health { get; private set; }

    public event Action OnTakeDamage;
    public event Action OnUpdateUI;

    public void DealHealthDamage(float damage, bool isImpact)
    {
        OnTakeDamage?.Invoke();
        Debug.Log("1");
    }

    public void Healing(float value)
    {
    }
}
