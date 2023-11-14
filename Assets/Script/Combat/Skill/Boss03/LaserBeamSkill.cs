using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamSkill : Skill
{
    [SerializeField] private GameObject LeserBeam;
    [SerializeField] private Vector3[] instantiatePos;
    [SerializeField] private Vector3[] instantiateRotate;

    private void Start()
    {
        UseSkill();
    }

    public override void UseSkill()
    {
        for (int i = 0; i < instantiatePos.Length; i++)
        {
            Instantiate(LeserBeam, instantiatePos[i], Quaternion.Euler(instantiateRotate[0]));
            Debug.Log(Time.time);
        }
    }
}
