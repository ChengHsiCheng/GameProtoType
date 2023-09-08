using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueSkill : Skill
{
    // [SerializeField] private Vector3 originPos;
    // [SerializeField] private Vector3 targetPos;
    // private Vector3 destination;

    // private bool isGoing;
    // private bool isBacking;

    // [SerializeField] float speed = 20f; // 移動速度



    // public override void UseSkill()
    // {
    //     originPos = transform.position;
    //     targetPos = RayCastHit() + transform.forward;
    //     destination = targetPos;

    //     isGoing = true;
    // }

    // private void Update()
    // {
    //     if (GameManager.isPauseGame)
    //         return;

    //     if (Input.GetKeyUp(KeyCode.Space))
    //     {
    //         UseSkill();
    //     }

    //     if (!isGoing && !isBacking)
    //         return;

    //     // 使用 MoveTowards 方法使物件向目標位置移動
    //     transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

    //     // 檢查物件是否到達目標位置
    //     if (transform.position == destination)
    //     {
    //         if (isGoing)
    //         {
    //             isGoing = false;
    //             destination = originPos;
    //             isBacking = true;
    //             return;
    //         }

    //         if (isBacking)
    //         {
    //             isBacking = false;
    //         }
    //     }
    // }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.tag != "Player")
    //         return;

    //     if (other.TryGetComponent<Health>(out Health health))
    //     {
    //         health.DealHealthDamage(damage, true);
    //     }

    //     if (other.TryGetComponent<San>(out San san))
    //     {
    //         san.DealSanDamage(sanDamage);
    //     }

    //     if (isGoing)
    //     {
    //         isGoing = false;
    //         destination = originPos;
    //         isBacking = true;
    //     }
    // }

    // protected Vector3 RayCastHit()
    // {
    //     RaycastHit hit;
    //     int layerMask = LayerMask.GetMask("Default");


    //     if (Physics.Raycast(transform.position, transform.forward, out hit, 50, layerMask))
    //     {
    //         return hit.point;
    //     }
    //     return Vector3.zero;
    // }

}
