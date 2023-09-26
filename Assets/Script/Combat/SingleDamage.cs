using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDamage : MonoBehaviour
{
    [SerializeField] private float damage; // 傷害
    [SerializeField] private float sanDamage;
    [SerializeField] private float impact;

    private Health health { get => GameManager.player.GetComponent<Health>(); }
    private San san { get => GameManager.player.GetComponent<San>(); }
    private ForceReceiver forceReceiver { get => GameManager.player.GetComponent<ForceReceiver>(); }

    private bool hasDamaged = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasDamaged)
            return;

        if (other.tag == "Player")
        {
            Vector3 dir = other.transform.position - transform.position;
            dir.y = 0;

            forceReceiver.AddForce(dir.normalized * impact);
            health.DealHealthDamage(damage, true);
            san.DealSanDamage(sanDamage);

            hasDamaged = true;
        }
    }
}
