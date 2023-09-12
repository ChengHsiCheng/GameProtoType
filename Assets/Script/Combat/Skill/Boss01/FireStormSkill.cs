using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStormSkill : Skill
{
    [SerializeField] ContinuousDamage damageType;

    public override void UseSkill()
    {
        // damageType.SetDamage(damage, sanDamage);
    }

    public override void DestroySkill()
    {
        Destroy(gameObject);
    }
}
