using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemySkill
{
    [field: SerializeField] public string SkillName { get; private set; } // 動畫名稱
    [field: SerializeField] public Skill skill { get; private set; }
    [field: SerializeField] public Transform spawnPoint { get; private set; }
    [field: SerializeField, HeaderAttribute("最大硬直時間")] public float MinCooldownTime { get; private set; }
    [field: SerializeField, HeaderAttribute("最小硬直時間")] public float MaxCooldownTime { get; private set; }
    [field: SerializeField, HeaderAttribute("擊退值")] public float Impact { get; private set; }

}
