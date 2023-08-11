using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponHendler : MonoBehaviour
{
    [SerializeField] private GameObject[] weaponLogic;

    /// <summary>
    /// 開啟武器碰撞
    /// </summary>
    protected void EnableWeapon(int Index)
    {
        weaponLogic[Index]?.SetActive(true);

        Debug.Log("ON");
    }

    /// <summary>
    /// 關閉武器碰撞
    /// </summary>
    private void DisableWeapon(int Index)
    {
        weaponLogic[Index]?.SetActive(false);

        Debug.Log("OFF");
    }
}
