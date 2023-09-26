    using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ContinuousDamage : Damage
{
    private float timer;

    private Health health { get => GameManager.player.GetComponent<Health>(); }
    private San san { get => GameManager.player.GetComponent<San>(); }

    void Update()
    {
        if (GameManager.isPauseGame)
            return;

        timer += Time.deltaTime;

        if (!trigger.IsInRadius)
            return;

        if (timer < 0.1f)
            return;

        timer -= 0.1f;

        health.DealHealthDamage(damage, false);
        san.DealSanDamage(sanDamage);
    }
}
