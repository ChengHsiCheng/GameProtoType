using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponHendler : MonoBehaviour
{
    [SerializeField] private GameObject[] weaponLogic;

    public event Action MoveEvent;

    /// <summary>
    /// 開啟武器碰撞
    /// </summary>
    protected void EnableWeapon(int Index)
    {
        weaponLogic[Index]?.SetActive(true);
    }

    /// <summary>
    /// 關閉武器碰撞
    /// </summary>
    private void DisableWeapon(int Index)
    {
        weaponLogic[Index]?.SetActive(false);
    }

    protected void AttackMove()
    {
        MoveEvent?.Invoke();
    }
}
