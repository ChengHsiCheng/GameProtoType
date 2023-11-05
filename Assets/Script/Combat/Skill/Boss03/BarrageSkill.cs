using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageSkill : Skill
{
    [SerializeField] private BarrageController barrageController;

    public override void UseSkill()
    {
        barrageController.SetInstantiatePos(castTransform);
        barrageController.Shoot();
    }
}
