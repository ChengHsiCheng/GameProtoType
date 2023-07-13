using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueSkill : Skill
{
    [SerializeField] private Vector3 originPos;
    [SerializeField] private Vector3 targetPos;

    public float speed = 20f; // 移動速度

    private bool keepMoving = true;
    private bool isMovingToEnd = true; // 指示物件是否正在向終點移動

    private void Start()
    {
        originPos = transform.position;
        targetPos = RayCastHit();
    }

    private void Update()
    {
        // 根據 isMovingToEnd 的值選擇目標位置
        Vector3 targetPosition = isMovingToEnd ? targetPos : originPos;

        // 使用 MoveTowards 方法使物件向目標位置移動
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // 檢查物件是否到達目標位置
        if (transform.position == targetPosition)
        {
            if (keepMoving)
            {
                isMovingToEnd = !isMovingToEnd;
                keepMoving = false;
                return;
            }

            Destroy(gameObject);
        }
    }

    protected Vector3 RayCastHit()
    {
        RaycastHit hit;
        int layerMask = LayerMask.GetMask("Default");


        if (Physics.Raycast(transform.position, transform.forward, out hit, 50, layerMask))
        {
            Debug.Log(hit.point);
            return hit.point;
        }
        return Vector3.zero;
    }
}
