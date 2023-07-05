using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyAttack
{
    [field: SerializeField, HeaderAttribute("動畫名稱")] public string AnimationName { get; private set; } // 動畫名稱
    [field: SerializeField, HeaderAttribute("動畫過渡時間")] public float TransitionDuration { get; private set; } // 過渡時間
    [field: SerializeField, HeaderAttribute("傷害值")] public int Damage { get; private set; } // 傷害值
    [field: SerializeField, HeaderAttribute("硬直時間")] public int CooldownTime { get; private set; } // 傷害值
}