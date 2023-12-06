using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ContinuousDamage : Damage
{
    private float timer;

    [SerializeField] private float startTime;
    [SerializeField] private float stopTime;
    [SerializeField] private float time;

    private Health health { get => GameManager.player.GetComponent<Health>(); }
    private San san { get => GameManager.player.GetComponent<San>(); }

    void Update()
    {
        if (GameManager.isPauseGame)
            return;

        timer += Time.deltaTime;
        time += Time.deltaTime;

        if (time < startTime || time > stopTime)
            return;

        if (!trigger.IsInRadius)
            return;

        if (timer < 0.1f)
            return;

        timer = 0f;

        health.DealHealthDamage(damage, false);
        san.DealSanDamage(sanDamage);
    }
}
