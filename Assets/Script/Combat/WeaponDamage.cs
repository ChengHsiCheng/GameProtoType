using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] private Collider myCollider;
    [SerializeField] private Collider Collider;
    [SerializeField] private AudioLogic audioLogic;
    [SerializeField] private CinemachineImpulseSource impulseSource;
    private float shockingPower;
    private float damage; // 傷害
    private float sanDamage;
    private float impact;
    private bool isStuckFrame;
    private float stuckFrameTime;

    [SerializeField] private GameObject hitVFX;
    [SerializeField] private List<GameObject> alreadyCollidedWith = new List<GameObject>(); // 已經碰撞過的碰撞器列表

    /// <summary>
    /// 啟用時
    /// </summary>

    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider)
            return;

        if (other.tag == myCollider.tag)
            return;

        if (alreadyCollidedWith.Contains(other.gameObject))
            return;

        Debug.Log(other.name);

        if (isStuckFrame)
        {
            StartCoroutine(StuckFrame());
        }

        alreadyCollidedWith.Add(other.gameObject);

        audioLogic?.PlayAudio("Hit");

        if (impulseSource)
        {
            impulseSource.GenerateImpulse(Vector3.one * shockingPower);
        }

        if (hitVFX)
        {
            Instantiate(hitVFX, other.ClosestPoint(transform.position), Quaternion.identity);
        }

        if (other.TryGetComponent<ForceReceiver>(out ForceReceiver force))
        {
            Vector3 _force = other.transform.position - myCollider.transform.position;
            _force.y = 0;
            force.AddForce(_force.normalized * impact);
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
        SetAttack(damage, impact, sanDamage, 0);
    }

    public void SetAttack(float damage, float impact, float sanDamage, float shockingPower)
    {
        this.damage = damage;
        this.impact = impact;
        this.sanDamage = sanDamage;
        this.shockingPower = shockingPower;
    }

    public void SetStuckFrame()
    {
        SetStuckFrame(0.05f);
    }

    public void SetStuckFrame(float stuckFrameTime)
    {
        isStuckFrame = true;
        this.stuckFrameTime = stuckFrameTime;
    }

    private IEnumerator StuckFrame()
    {
        GameManager.TogglePause(true);

        yield return new WaitForSeconds(stuckFrameTime);

        GameManager.TogglePause(false);
        isStuckFrame = false;
    }

}
