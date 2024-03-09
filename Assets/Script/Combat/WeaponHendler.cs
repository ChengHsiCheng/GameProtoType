using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponHendler : MonoBehaviour
{
    [SerializeField] private WeaponDamage[] weaponLogic;

    public event Action MoveEvent;
    public event Action<string> VFXEvent;

    /// <summary>
    /// 開啟武器碰撞
    /// </summary>
    public void EnableWeapon(int Index)
    {
        weaponLogic[Index]?.SetCollider(true);

        Debug.Log("EnableWeapon");
    }

    /// <summary>
    /// 關閉武器碰撞
    /// </summary>
    public void DisableWeapon(int Index)
    {
        weaponLogic[Index]?.SetCollider(false);
        Debug.Log("DisableWeapon");
    }

    public void DisableWeapon()
    {
        DisableWeapon(0);
    }

    private void AttackMove()
    {
        MoveEvent?.Invoke();
    }

    private void PlayVFX(string name)
    {
        VFXEvent?.Invoke(name);
    }

    internal void EnableWeapon()
    {
        throw new NotImplementedException();
    }
}
