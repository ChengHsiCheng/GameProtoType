using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ContinuousDamage : MonoBehaviour
{
    [SerializeField] private Trigger trigger;
    [SerializeField] private float damage; // 傷害
    [SerializeField] private float sanDamage;

    private float timer;

    private Health health { get => GameManager.player.GetComponent<Health>(); }
    private San san { get => GameManager.player.GetComponent<San>(); }

    void Update()
    {
        if (GameManager.isPauseGame)
            return;

        timer += Time.deltaTime;

        if (timer < 0.05f)
            return;

        timer -= 0.05f;

        if (!trigger.IsInRadius)
            return;

        health.DealHealthDamage(damage, false);
        san.DealSanDamage(sanDamage);
    }
}
