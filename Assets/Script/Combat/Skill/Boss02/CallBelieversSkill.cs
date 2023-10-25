using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBelieversSkill : Skill
{
    [SerializeField] private Crown crown;
    [SerializeField] private GameObject[] believers;
    private GameObject firstBelievers;

    public override void UseSkill()
    {
        if (!GameObject.FindObjectOfType<Crown>())
        {
            firstBelievers = Instantiate(believers[Random.Range(0, believers.Length)], new Vector3(Random.Range(-8f, 8f), 0, Random.Range(-8f, 8f)), Quaternion.identity);
            Instantiate(crown, Vector3.zero, Quaternion.identity).SetCrownHolder(firstBelievers);
        }

        for (int i = 0; i < 4; i++)
        {
            Instantiate(believers[Random.Range(0, believers.Length)], new Vector3(Random.Range(-8f, 8f), 0, Random.Range(-8f, 8f)), Quaternion.identity);
        }
    }
}
