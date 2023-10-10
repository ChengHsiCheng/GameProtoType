using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] private Collider myCollider;
    [SerializeField] private Collider Collider;
    [SerializeField] private AudioLogic audioLogic;
    private float damage; // 傷害
    private float sanDamage;
    private float impact;

    [SerializeField] private GameObject hitVFX;
    [SerializeField] private List<GameObject> alreadyCollidedWith = new List<GameObject>(); // 已經碰撞過的碰撞器列表

    /// <summary>
    /// 啟用時
    /// </summary>

    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider)
            return;

        if (alreadyCollidedWith.Contains(other.gameObject))
            return;

        alreadyCollidedWith.Add(other.gameObject);

        audioLogic?.PlayAudio("Hit");

        Debug.Log(other.name);

        if (hitVFX)
        {
            Instantiate(hitVFX, other.ClosestPoint(transform.position), Quaternion.identity);
        }

        if (other.TryGetComponent<ForceReceiver>(out ForceReceiver force))
        {
            force.AddForce((other.transform.position - myCollider.transform.position).normalized * impact);
        }

        if (other.TryGetComponent<Health>(out Health health))
        {
            health.DealHealthDamage(damage, impact > 0);
        }

        if (sanDamage == 0)
            return;

        if (other.TryGetComponent<San>(out San san))
        {
            san.DealSanDamage(sanDamage);
        }
    }

    public void SetCollider(bool isEnabled)
    {
        Collider.enabled = isEnabled;

        if (isEnabled)
            alreadyCollidedWith.Clear();
    }


    public void SetAttack(float damage)
    {
        SetAttack(damage, 0);
    }


    public void SetAttack(float damage, float impact)
    {
        SetAttack(damage, impact, 0);

    }


    public void SetAttack(float damage, float impact, float sanDamage)
    {
        this.damage = damage;
        this.impact = impact;
        this.sanDamage = sanDamage;
    }

}
