using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform target;           // 跟隨的目標
    [SerializeField] Transform faceTarget;
    [SerializeField] float rotationSpeed;
    [SerializeField] float followSpeed = 5f;     // 跟隨的速度
    [SerializeField] float minimumDistance = 2f; // 最小距離，保持在目標前面的距離
    [SerializeField] LayerMask obstacleLayer;    // 障礙物圖層

    private void Update()
    {
        if (faceTarget)
        {
            // 使物件始終面向目標
            FaceTarget();
        }

        if (Vector3.Distance(target.position, transform.position) <= 0.2)
            return;

        // 計算從當前位置到目標位置的方向
        Vector3 moveDirection = target.position - transform.position;

        // 檢查是否有障礙物在前方
        if (Physics.Raycast(transform.position, moveDirection, out RaycastHit hit, minimumDistance, obstacleLayer))
        {
            // 如果有障礙物，則避免碰撞，將移動方向調整為右側（或左側，根據需要）
            transform.position += (target.position - transform.position - transform.right * 3) * Time.deltaTime * followSpeed;
            Debug.Log("HIT!!");
            return;
        }

        transform.position += (target.position - transform.position) * Time.deltaTime * followSpeed;
    }

    protected void FaceTarget()
    {
        if (!faceTarget)
            return;

        Vector3 targetPosition = faceTarget.position;
        targetPosition.y = transform.position.y;

        Vector3 direction = targetPosition - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
