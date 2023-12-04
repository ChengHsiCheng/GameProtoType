using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Boss02Altar : MonoBehaviour, Health
{
    [SerializeField] private VisualEffect shield;
    [SerializeField] private GameObject shieldBroken;
    [SerializeField] private int shieldBrokenDemand;
    private int shieldBrokenCount;
    private bool Invulnerable;
    private float shieldColor;
    [SerializeField] private float shieldCoolerSpeed;
    private bool isShieldColor;

    public event Action OnShieldBrokenEvent;

    public event Action OnTakeDamage;
    public event Action<float> OnTakeDamageEvent;
    public event Action OnUpdateUI;

    [field: SerializeField] public float maxHealth { get; private set; }
    [field: SerializeField] public float health { get; private set; }

    private void Start()
    {
        ShieldRepair();

        health = maxHealth;
    }

    private void Update()
    {
        if (GameManager.isPauseGame)
            return;

        shield.SetFloat("ChangeColor", shieldColor);

        if (isShieldColor)
        {
            shieldColor += shieldCoolerSpeed * Time.deltaTime;

            if (shieldColor >= 1)
            {
                isShieldColor = false;
            }
            return;
        }

        shieldColor = MathF.Max(0, shieldColor - shieldCoolerSpeed * Time.deltaTime);

    }

    public void ShieldBrokenCountReduced()
    {
        shieldBrokenCount++;

        isShieldColor = true;

        if (shieldBrokenCount == shieldBrokenDemand)
        {
            ShieldBroken();
        }
    }

    private void ShieldBroken()
    {
        shield.Stop();
        Invulnerable = false;
        OnShieldBrokenEvent?.Invoke();
        shieldBrokenCount = 0;

        Boss02BelieverStateMachine[] Believers = GameObject.FindObjectsOfType<Boss02BelieverStateMachine>();

        foreach (Boss02BelieverStateMachine Believer in Believers)
        {
            Believer.OnFaint();
            Debug.Log(Believer);
        }
    }

    public void ShieldRepair()
    {
        shield.Play();
        Invulnerable = true;

        Boss02BelieverStateMachine[] Believers = GameObject.FindObjectsOfType<Boss02BelieverStateMachine>();

        foreach (Boss02BelieverStateMachine Believer in Believers)
        {
            Believer.DisFaint();
        }
    }

    public void DealHealthDamage(float damage, bool isImpact)
    {
        if (Invulnerable)
            return;

        OnTakeDamageEvent?.Invoke(damage);

        health = MathF.Max(health - damage, 0);
    }

    public void Healing(float value)
    {
    }
}
