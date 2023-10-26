using System;
using System.Collections;
using System.Collections.Generic;
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

    public float maxHealth { get; private set; }
    public float health { get; private set; }

    private bool isPlay;

    private PlayerStateMachine player;

    private void Start()
    {
        player = GameManager.player.GetComponent<PlayerStateMachine>();

        Info.OnTakeDamage += DealHealthDamage;

        SwitchBloodRitualAltarSkill(false);
        BloodRitualAltarVFX.SetFloat("Step", bloodRitualAltarVFXValue);

        BloodRitualAltarVFX.Stop();
    }

    private void OnDisable()
    {
        Info.OnTakeDamage -= DealHealthDamage;
    }

    private void Update()
    {
        if (isBloodRitualAltarVFX)
        {
            if (!isPlay)
            {
                BloodRitualAltarVFX.Play();
                isPlay = true;
            }
            bloodRitualAltarVFXValue = Mathf.Lerp(bloodRitualAltarVFXValue, 0, bloodRitualAltarVFXSpeed * Time.deltaTime);
        }
        else
        {
            bloodRitualAltarVFXValue = Mathf.Lerp(bloodRitualAltarVFXValue, 2, bloodRitualAltarVFXSpeed * Time.deltaTime);

            if (bloodRitualAltarVFXValue >= 2 && isPlay)
            {
                BloodRitualAltarVFX.Stop();
                isPlay = false;
            }
        }

        BloodRitualAltarVFX.SetFloat("Step", bloodRitualAltarVFXValue);
    }

    public void DealHealthDamage()
    {
        Debug.Log("Hit");

        if (!player.haveCrown)
            return;

        Debug.Log(Info.health);

        float healthPercent = Info.health / Info.maxHealth;

        Bar.SetBar(healthPercent);
    }

    public void Healing(float value)
    {
    }

    public void SwitchBloodRitualAltarSkill(bool value)
    {

    }
}
