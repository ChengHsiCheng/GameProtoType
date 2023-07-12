using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public float maxHealth { get; private set; } // 最大血量值
    public float health { get; private set; } // 當前血量值
    private bool isInvulnerable; // 是否無敵
    public event Action OnTakeDamage; // 受到傷害事件
    public event Action OnDie; // 死亡事件

    public bool isDead => health == 0; // 是否已死亡

    private void Start()
    {
        health = maxHealth;
    }

    /// <summary>
    /// 設定無敵狀態
    /// </summary>
    public void SetInvulnerable(bool isInvunerable)
    {
        this.isInvulnerable = isInvunerable;
    }

    /// <summary>
    /// 給與傷害
    /// </summary>
    public void DealDamage(int damage)
    {
        if (health == 0)
            return;

        if (isInvulnerable)
            return;

        // 扣除傷害值，血量不低於0
        health = Mathf.Max(health - damage, 0);

        OnTakeDamage?.Invoke();

        if (health == 0)
        {
            OnDie?.Invoke();
        }

        Debug.Log(health);
    }
}
