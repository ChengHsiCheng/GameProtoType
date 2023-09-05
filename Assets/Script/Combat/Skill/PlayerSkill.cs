using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class PlayerSkill
{
    public string name;
    [field: SerializeField, HeaderAttribute("續力時間")] public float ChargeTime { get; private set; } // 續力時間
    [field: SerializeField] public Skill skill { get; private set; }
    [field: SerializeField] public float sanCost { get; private set; }
}
