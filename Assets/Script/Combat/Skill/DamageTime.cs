using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTime : MonoBehaviour
{
    [SerializeField] private Collider Collider;
    [SerializeField] private float damageTime;

    private float timer;

    private void Update()
    {
        if (GameManager.isPauseGame)
            return;

        timer += Time.deltaTime;

        if (timer >= damageTime && Collider.enabled)
        {
            Collider.enabled = false;
        }
    }
}
