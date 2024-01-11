using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Attack
{
    [field: SerializeField, HeaderAttribute("動畫名稱")] public string AnimationName { get; private set; } // 動畫名稱
    [field: SerializeField, HeaderAttribute("攻擊時間")] public float AttackTimeByAnimation { get; private set; }
    [field: SerializeField, HeaderAttribute("動畫過渡時間")] public float TransitionDuration { get; private set; } // 過渡時間
    [field: SerializeField, HeaderAttribute("連擊狀態計數")] public int ComboStateIndex { get; private set; } = -1; // 連擊狀態計數
    [field: SerializeField, HeaderAttribute("最小旋轉時間(0-1)")] public float RotateTime { get; private set; } // 連擊攻擊時間
    [field: SerializeField, HeaderAttribute("最小取消動作時間(0-1)")] public float minCancelTime { get; private set; } // 連擊攻擊時間
    [field: SerializeField, HeaderAttribute("最大連擊攻擊時間(0-1)")] public float MaxComboAttackTime { get; private set; } // 連擊攻擊時間
    [field: SerializeField, HeaderAttribute("最小連擊攻擊時間(0-1)")] public float MinComboAttackTime { get; private set; } // 連擊攻擊時間
    [field: SerializeField, HeaderAttribute("移動時間(0-1)")] public float MoveTime { get; private set; } // 移動時間
    [field: SerializeField, HeaderAttribute("移動力量")] public float MoveForce { get; private set; } // 移動力量
    [field: SerializeField, HeaderAttribute("傷害值")] public int Damage { get; private set; } // 傷害值
    [field: SerializeField, HeaderAttribute("畫面震動力量")] public int ShockingPower { get; private set; }

    public GameObject Model;

}
