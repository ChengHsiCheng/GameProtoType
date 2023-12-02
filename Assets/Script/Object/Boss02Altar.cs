using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02Altar : MonoBehaviour, Health
{
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject shieldBroken;
    [SerializeField] private int shieldBrokenDemand;
    private int shieldBrokenCount;
    private bool Invulnerable;

    public event Action OnTakeDamage;
    public event Action OnUpdateUI;

    [field: SerializeField] public float maxHealth { get; private set; }
    [field: SerializeField] public float health { get; private set; }

    private void Start()
    {
        shield.SetActive(true);
        Invulnerable = true;

        health = maxHealth;
    }

    public void ShieldBrokenCountReduced()
    {
        shieldBrokenCount++;

        Debug.Log(shieldBrokenCount);

        if (shieldBrokenCount == shieldBrokenDemand)
        {
            shield.SetActive(false);
            Invulnerable = false;
        }
    }

    public void DealHealthDamage(float damage, bool isImpact)
    {
        if (Invulnerable)
            return;

        OnTakeDamage?.Invoke();

        health = MathF.Max(health - damage, 0);
    }

    public void Healing(float value)
    {
    }
}
