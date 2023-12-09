using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02BelieverRangeSkill : Skill
{
    [SerializeField] private GameObject CastVFX;

    private Vector3 pos;

    public override void UseSkill()
    {
        pos = GameManager.player.transform.position;
        Instantiate(CastVFX, pos, Quaternion.identity);
    }

}
