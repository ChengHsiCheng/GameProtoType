using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] protected float damage;
    [SerializeField] protected float sanDamage;

    public virtual void SkillUpdate() { }

    public virtual void UseSkill() { }
    public virtual void DestroySkill() { }
}
