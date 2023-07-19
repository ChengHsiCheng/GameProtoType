using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHendler : MonoBehaviour
{
    [SerializeField] private GameObject[] weaponLogic;

    /// <summary>
    /// 開啟武器碰撞
    /// </summary>
    public void EnableWeapon(int Index)
    {
        weaponLogic[Index]?.SetActive(true);
    }

    /// <summary>
    /// 關閉武器碰撞
    /// </summary>
    public void DisableWeapon(int Index)
    {
        weaponLogic[Index]?.SetActive(false);
    }
}
