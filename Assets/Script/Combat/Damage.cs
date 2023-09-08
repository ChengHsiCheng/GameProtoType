using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] protected Trigger trigger;

    protected float damage = 1; // 傷害
    protected float sanDamage = 1;

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void SetDamage(float damage, float sanDamage)
    {
        SetDamage(damage);
        this.sanDamage = sanDamage;
    }
}
