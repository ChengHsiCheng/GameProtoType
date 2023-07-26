using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousDamage : MonoBehaviour
{
    [SerializeField] private float damage; // 傷害
    [SerializeField] private float sanDamage;
    [SerializeField] private float damageTime;

    private bool IsInRadius;
    private float timer;

    private Health health { get => GameManager.player.GetComponent<Health>(); }
    private San san { get => GameManager.player.GetComponent<San>(); }

    void Update()
    {
        if (GameManager.isPauseGame)
            return;

        if (timer >= damageTime)
            return;

        timer += Time.deltaTime;

        if (!IsInRadius)
            return;

        health.DealHealthDamage(damage, false);
        san.DealSanDamage(sanDamage);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsInRadius = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            IsInRadius = false;
        }
    }
}
