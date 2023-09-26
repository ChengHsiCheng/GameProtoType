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
    [field: SerializeField, HeaderAttribute("San傷害值")] public int SanDamage { get; private set; } // San傷害值
    [field: SerializeField, HeaderAttribute("擊退值")] public float Impact { get; private set; }
    [field: SerializeField, HeaderAttribute("最大硬直時間")] public float MaxCooldownTime { get; private set; }
    [field: SerializeField, HeaderAttribute("最小硬直時間")] public float MinCooldownTime { get; private set; }
    [field: SerializeField, HeaderAttribute("移動時間(0-1)")] public float MoveTime { get; private set; } // 移動時間
    [field: SerializeField, HeaderAttribute("移動力量")] public float MoveForce { get; private set; } // 移動力量

}