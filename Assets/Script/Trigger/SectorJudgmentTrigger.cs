using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SectorJudgmentTrigger : Trigger
{
    public float Radius = 10f; // 視野距離
    public float viewAngleStep = 20; // 射線數量
    public float angle = 45;
    public float startAngle = 0;

    private void Update()
    {
        LookAround();
    }

    public void LookAround()
    {
        // 射線從左邊開始，角度為-45;
        Vector3 forwardLeft = Quaternion.Euler(0, -(angle / 2) + startAngle, 0) * transform.forward * Radius;

        for (int i = 0; i <= viewAngleStep; i++)
        {

            // 射線由forwardLeft基礎點偏轉
            Vector3 vector = Quaternion.Euler(0, (angle / viewAngleStep) * i, 0) * forwardLeft;


            // 建立射線
            Ray ray = new Ray(transform.position, vector);
            RaycastHit hits = new RaycastHit();

            // Layer 碰撞偵測
            int mask = LayerMask.GetMask("Player");
            Physics.Raycast(ray, out hits, mask);

            // targets位置 + vector = 射線最終位置
            Vector3 pos = transform.position + vector;
            Debug.DrawLine(transform.position, pos, Color.red);

            // 射線碰撞到，就當碰撞點
            if (hits.transform != null)
                pos = hits.point;

            Debug.DrawLine(transform.position, pos, Color.red);

            // 碰到敵人在處理
            if (hits.transform != null && hits.transform.gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
            {
                // 射線長度
                float value = Vector3.Distance(transform.position, hits.collider.transform.position);

                Debug.Log(hits.collider.gameObject + "距離: " + value);


                if (value <= Radius)
                {
                    IsInRadius = true;
                    return;
                }
            }
        }

        IsInRadius = false;
    }
}
