using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedVestmentSkill : Skill
{
    [SerializeField] private Crown crown;
    [SerializeField] private GameObject[] believers;
    private GameObject firstBelievers;

    public override void UseSkill()
    {
        firstBelievers = Instantiate(believers[0], new Vector3(Random.Range(-8f, 8f), 0, Random.Range(-8f, 8f)), Quaternion.identity);
        Instantiate(crown, Vector3.zero, Quaternion.identity).SetCrownHolder(firstBelievers);

        for (int i = 0; i < 3; i++)
        {
            Instantiate(believers[0], new Vector3(Random.Range(-8f, 8f), 0, Random.Range(-8f, 8f)), Quaternion.identity);
        }
    }
}
