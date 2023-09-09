using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueSkill : Skill
{
    [SerializeField] private Vector3 originPos;
    [SerializeField] private Vector3 targetPos;

    [SerializeField] private Transform tongue;
    private Vector3 destination;

    [SerializeField] private bool isGoing;
    [SerializeField] private bool isBacking;

    [SerializeField] float speed = 20f; // 移動速度

    [SerializeField] TongueSkillTrigger trigger;

    public override void UseSkill()
    {
        trigger.TriggerEvent += OnTrigger;

        originPos = tongue.transform.position;
        targetPos = RayCastHit() + tongue.transform.forward;
        destination = targetPos;

        isGoing = true;
    }

    public override void DestroySkill()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (GameManager.isPauseGame)
            return;


        if (isBacking)
        {
            tongue.position = Vector3.MoveTowards(tongue.position, destination, speed);
            if (Vector3.Distance(tongue.position, originPos) < 0.01f)
            {
                isBacking = false;
            }
            return;
        }

        if (isGoing)
        {
            tongue.position = Vector3.MoveTowards(tongue.position, destination, speed);
            if (Vector3.Distance(tongue.position, targetPos) < 0.01f)
            {
                destination = originPos;
                isGoing = false;
                isBacking = true;
            }
        }

    }

    private void OnTrigger(Collider other)
    {
        if (other.tag != "Player")
            return;

        if (other.TryGetComponent<Health>(out Health health))
        {
            health.DealHealthDamage(damage, true);
        }

        if (other.TryGetComponent<San>(out San san))
        {
            san.DealSanDamage(sanDamage);
        }

        if (isGoing)
        {
            isGoing = false;
            destination = originPos;
            isBacking = true;
        }
    }

    protected Vector3 RayCastHit()
    {
        RaycastHit hit;
        int layerMask = LayerMask.GetMask("Default");


        if (Physics.Raycast(transform.position, transform.forward, out hit, 50, layerMask))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}

