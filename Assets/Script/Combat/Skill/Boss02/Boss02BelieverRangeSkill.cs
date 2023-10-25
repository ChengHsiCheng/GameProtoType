using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02BelieverRangeSkill : Skill
{
    [SerializeField] private GameObject CastVFX;
    [SerializeField] private GameObject ExplodeVFX;

    private Vector3 pos;

    public override void UseSkill()
    {
        pos = GameManager.player.transform.position;
        Instantiate(CastVFX, pos, Quaternion.identity);

        Invoke("Explode", 2f);
    }

    private void Explode()
    {
        Instantiate(ExplodeVFX, pos, Quaternion.identity);
    }
}
