using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDamage : MonoBehaviour
{
    [SerializeField] private float damage; // 傷害
    [SerializeField] private float sanDamage;

    private Health health { get => GameManager.player.GetComponent<Health>(); }
    private San san { get => GameManager.player.GetComponent<San>(); }

    private bool hasDamaged = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasDamaged)
            return;

        if (other.tag == "Player")
        {
            health.DealHealthDamage(damage);
            san.DealSanDamage(sanDamage);

            hasDamaged = true;
        }
    }
}
