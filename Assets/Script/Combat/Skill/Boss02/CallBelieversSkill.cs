using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBelieversSkill : Skill
{
    [SerializeField] private GameObject[] believers;
    [SerializeField] private Vector3[] pos;

    public override void UseSkill()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(believers[0], new Vector3(Random.Range(-8f, 8f), 0, Random.Range(-8f, 8f)), Quaternion.identity);
        }

        for (int i = 0; i < pos.Length; i++)
        {
            Instantiate(believers[1], pos[i], Quaternion.identity);
        }
    }
}
