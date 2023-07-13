using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Health
{
    float maxHealth { get; }
    float health { get; }
    bool isDead { get; }
    bool isInvulnerable { get; set; }
    event Action OnTakeDamage;
    event Action OnDie;

    void SetInvulnerable(bool isInvunerable);
    void DealDamage(float damage);
}
