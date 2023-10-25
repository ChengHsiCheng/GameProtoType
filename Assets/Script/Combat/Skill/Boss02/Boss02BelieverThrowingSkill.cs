using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss02BelieverThrowingSkill : Skill
{
    [SerializeField] private GameObject CastVFX;
    [SerializeField] private ProjectileControls ProjectileVFX;

    public override void UseSkill()
    {
        Instantiate(CastVFX, castTransform);
        Invoke("Emission", 0.5f);
    }

    private void Emission()
    {
        ProjectileControls projectile = Instantiate(ProjectileVFX, castTransform.position, castTransform.rotation);
        projectile.SetValue(5, castTransform.transform.forward);
    }
}
