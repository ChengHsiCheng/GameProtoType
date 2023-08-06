using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] private Collider myCollider;
    private float damage; // 傷害
    private float sanDamage;

    [SerializeField] private GameObject hitVFX;
    [SerializeField] private List<GameObject> alreadyCollidedWith = new List<GameObject>(); // 已經碰撞過的碰撞器列表

    /// <summary>
    /// 啟用時
    /// </summary>
    private void OnEnable()
    {
        alreadyCollidedWith.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider)
            return;

        if (alreadyCollidedWith.Contains(other.gameObject))
            return;

        alreadyCollidedWith.Add(other.gameObject);

        if (hitVFX)
        {
            Instantiate(hitVFX, other.ClosestPoint(transform.position), Quaternion.identity);
        }

        if (other.TryGetComponent<Health>(out Health health))
        {
            health.DealHealthDamage(damage, true);
        }

        if (sanDamage == 0)
            return;

        if (other.TryGetComponent<San>(out San san))
        {
            san.DealSanDamage(sanDamage);
        }
    }

    /// <summary>
    /// 設定攻擊參數
    /// </summary>
    public void SetAttack(float damage)
    {
        SetAttack(damage, 0);
    }

    /// <summary>
    /// 設定攻擊參數
    /// </summary>
    public void SetAttack(float damage, int sanDamage)
    {
        this.damage = damage;
        this.sanDamage = sanDamage;
    }
}
