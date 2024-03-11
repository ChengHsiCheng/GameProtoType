using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBelieversSkill : Skill
{
    [SerializeField] private GameObject[] believers;
    [SerializeField] private Vector3[] pos;

    private int amount;

    public override void UseSkill()
    {
        Debug.Log(amount);
        Debug.Log(pos.Length);

        for (int i = 0; i < amount / 2; i++)
        {
            Debug.Log("AA" + i);
            Instantiate(believers[0], new Vector3(Random.Range(-6f, 6f), 0, Random.Range(-6f, 6f)), new Quaternion(0, Random.Range(0, 360), 0, 0));
        }

        for (int i = 0; i < amount / 2; i++)
        {
            Instantiate(believers[1], pos[i], new Quaternion(0, Random.Range(0, 360), 0, 0));
        }
    }

    public void SetBelieverAmount(int _amount)
    {
        amount = _amount;
    }
}
