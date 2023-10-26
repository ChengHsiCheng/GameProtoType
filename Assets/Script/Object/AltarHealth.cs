using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class AltarHealth : MonoBehaviour
{
    [field: SerializeField] public EnemyInfo Info { get; private set; }
    [field: SerializeField] public BarController Bar { get; private set; }
    [field: SerializeField] public VisualEffect BloodRitualAltarVFX { get; private set; }

    private float bloodRitualAltarVFXValue = 2;
    [SerializeField] private bool isBloodRitualAltarVFX = false;
    [SerializeField] private float bloodRitualAltarVFXSpeed;

    private PlayerStateMachine player;
    private Boss02StateMachine boss02;

    private void Start()
    {
        player = GameManager.player.GetComponent<PlayerStateMachine>();

        Info.OnTakeDamage += DealHealthDamage;
        Info.OnDie += Die;

        SwitchBloodRitualAltarSkill(false);
    }

    private void OnDisable()
    {
        Info.OnTakeDamage -= DealHealthDamage;
        Info.OnDie -= Die;
    }

    private void Update()
    {
        if (isBloodRitualAltarVFX)
        {
            bloodRitualAltarVFXValue = MathF.Max(0, bloodRitualAltarVFXValue - (bloodRitualAltarVFXSpeed * Time.deltaTime));
        }
        else
        {
            bloodRitualAltarVFXValue = MathF.Min(2, bloodRitualAltarVFXValue + (bloodRitualAltarVFXSpeed * Time.deltaTime));
        }

        BloodRitualAltarVFX.SetFloat("Step", bloodRitualAltarVFXValue);
    }

    public void DealHealthDamage()
    {
        if (!player.haveCrown)
            return;

        Debug.Log(Info.health);

        float healthPercent = Info.health / Info.maxHealth;

        Bar.SetBar(healthPercent);
    }

    private void Die()
    {
        boss02.SwitchState(new Boss02DieState(boss02));
    }

    public void Healing(float value)
    {
        Info.Healing(value);
    }

    public void SwitchBloodRitualAltarSkill(bool value)
    {
        isBloodRitualAltarVFX = value;
        Debug.Log(isBloodRitualAltarVFX);
    }

    public void SetBoss02(Boss02StateMachine boss02)
    {
        this.boss02 = boss02;
    }
}
