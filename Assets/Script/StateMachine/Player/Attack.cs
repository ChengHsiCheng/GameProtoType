using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Attack
{
    [field: SerializeField, HeaderAttribute("動畫名稱")] public string AnimationName { get; private set; } // 動畫名稱
    [field: SerializeField, HeaderAttribute("攻擊開始時間")] public float AttackTimeByAnimation { get; private set; }
    [field: SerializeField, HeaderAttribute("攻擊結束時間")] public float AttackEndTimeByAnimation { get; private set; }
    [field: SerializeField, HeaderAttribute("動畫過渡時間")] public float TransitionDuration { get; private set; } // 過渡時間
    [field: SerializeField, HeaderAttribute("下一個輕攻擊")] public int lightComboStateIndex { get; private set; } = -1;
    [field: SerializeField, HeaderAttribute("下一個重攻擊")] public int HeavyComboStateIndex { get; private set; } = -1;
    [field: SerializeField, HeaderAttribute("最小旋轉時間(0-1)")] public float RotateTime { get; private set; } // 連擊攻擊時間
    [field: SerializeField, HeaderAttribute("前搖取消動作時間(0-1)")] public float PreCancelTime { get; private set; } // 連擊攻擊時間
    [field: SerializeField, HeaderAttribute("後搖取消動作時間(0-1)")] public float PostCancelTime { get; private set; } // 連擊攻擊時間
    [field: SerializeField, HeaderAttribute("最大連擊攻擊時間(0-1)")] public float MaxComboAttackTime { get; private set; } // 連擊攻擊時間
    [field: SerializeField, HeaderAttribute("最小連擊攻擊時間(0-1)")] public float MinComboAttackTime { get; private set; } // 連擊攻擊時間
    [field: SerializeField, HeaderAttribute("移動時間(0-1)")] public float MoveTime { get; private set; } // 移動時間
    [field: SerializeField, HeaderAttribute("移動力量")] public float MoveForce { get; private set; } // 移動力量
    [field: SerializeField, HeaderAttribute("傷害值")] public int Damage { get; private set; } // 傷害值
    [field: SerializeField, HeaderAttribute("畫面震動力量")] public int ShockingPower { get; private set; }
    [field: SerializeField, HeaderAttribute("播放音效時間")] public float AudioTime { get; private set; }
}
