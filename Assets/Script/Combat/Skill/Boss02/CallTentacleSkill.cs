using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallTentacleSkill : Skill
{
    [SerializeField] private GameObject tentacle;

    public override void UseSkill()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(tentacle, new Vector3(Random.Range(-8f, 8f), 0, Random.Range(-8f, 8f)), Quaternion.identity);
        }
    }
}
