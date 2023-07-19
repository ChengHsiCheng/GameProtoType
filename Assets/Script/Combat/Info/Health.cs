using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Health
{
    float maxHealth { get; }
    float health { get; }
    event Action OnTakeDamage;
    void DealHealthDamage(float damage);
}