using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AltarHealth : MonoBehaviour
{
    [field: SerializeField] public EnemyInfo Info { get; private set; }
    [field: SerializeField] public BarController Bar { get; private set; }

    public float maxHealth { get; private set; }
    public float health { get; private set; }

    private PlayerStateMachine player;

    private void Start()
    {
        player = GameManager.player.GetComponent<PlayerStateMachine>();

        Info.OnTakeDamage += DealHealthDamage;
    }

    private void OnDisable()
    {
        Info.OnTakeDamage -= DealHealthDamage;
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
}
