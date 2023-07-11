using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemySkill
{
    [field: SerializeField, HeaderAttribute("")] public Skill skill { get; private set; }
    [field: SerializeField, HeaderAttribute("生成位置")] public Transform spawnPoint { get; private set; }
}
