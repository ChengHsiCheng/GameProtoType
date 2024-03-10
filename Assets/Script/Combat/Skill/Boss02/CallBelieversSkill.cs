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
            Instantiate(believers[0], new Vector3(Random.Range(-6f, 6f), 0, Random.Range(-6f, 6f)), Quaternion.identity);
        }

        for (int i = 0; i < amount / 2; i++)
        {
            Instantiate(believers[1], pos[i], Quaternion.identity);
        }
    }

    public void SetBelieverAmount(int _amount)
    {
        amount = _amount;
    }
}
