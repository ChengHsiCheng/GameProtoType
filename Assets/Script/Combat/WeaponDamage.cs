using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] private Collider myCollider;
    private int damage; // 傷害

    [SerializeField] private List<Collider> alreadyCollidedWith = new List<Collider>(); // 已經碰撞過的碰撞器列表

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

        if (alreadyCollidedWith.Contains(other))
            return;

        alreadyCollidedWith.Add(other);

        if (other.TryGetComponent<Health>(out Health health))
        {
            health.DealDamage(damage);
        }
    }

    /// <summary>
    /// 設定攻擊參數
    /// </summary>
    public void SetAttack(int damage)
    {
        this.damage = damage;
    }
}
