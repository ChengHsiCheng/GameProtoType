using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamSkill : Skill
{
    [SerializeField] private int mode;
    [SerializeField] private GameObject LeserBeam;
    [SerializeField] private GameObject WarningArea;
    [SerializeField] private InstantiatePos[] instantiatePos;

    private void Start()
    {
        UseSkill();
    }

    public override void UseSkill()
    {
        mode = UnityEngine.Random.Range(0, instantiatePos.Length);

        for (int i = 0; i < instantiatePos[mode].pos.Length; i++)
        {
            Instantiate(LeserBeam, new Vector3(instantiatePos[mode].pos[i].x, 1.5f, instantiatePos[mode].pos[i].y), Quaternion.Euler(0, instantiatePos[mode].rotationY, 0));
            Instantiate(WarningArea, new Vector3(instantiatePos[mode].pos[i].x, 0, instantiatePos[mode].pos[i].y), Quaternion.Euler(0, instantiatePos[mode].rotationY, 0));
        }
    }
}

[Serializable]
public class InstantiatePos
{
    [field: SerializeField] public Vector2[] pos { get; private set; }
    [field: SerializeField] public float rotationY { get; private set; }
}