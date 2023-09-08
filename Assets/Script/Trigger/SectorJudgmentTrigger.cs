using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEditor;

public class SectorJudgmentTrigger : Trigger
{
    //扇形角度
    [SerializeField] private float angle = 80f;
    //扇形半径
    [SerializeField] private float radius = 3.5f;
    private Transform target;

    private void Start()
    {
        target = GameManager.player.transform;
    }

    private void Update()
    {
        IsInRadius = IsInRange(angle, radius, transform, target);
    }

    /// <summary>
    /// 判断target是否在扇形区域内
    /// </summary>
    /// <param name="sectorAngle">扇形角度</param>
    /// <param name="sectorRadius">扇形半径</param>
    /// <param name="attacker">攻击者的transform信息</param>
    /// <param name="target">目标</param>
    /// <returns>目标target在扇形区域内返回true 否则返回false</returns>
    public bool IsInRange(float sectorAngle, float sectorRadius, Transform attacker, Transform target)
    {
        //攻击者位置指向目标位置的向量
        Vector3 direction = target.position - attacker.position;
        direction.y = 0;
        //点乘积结果
        float dot = Vector3.Dot(direction.normalized, transform.forward);
        //反余弦计算角度
        float offsetAngle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        return offsetAngle < sectorAngle * .5f && direction.magnitude < sectorRadius;
    }

    private void OnDrawGizmos()
    {
        Handles.color = IsInRadius ? Color.cyan : Color.red;

        float halfAngle = angle / 2f;

        // 计算扇形的两个边缘点
        Vector3 direction = transform.forward;

        Vector3 leftVertex = transform.position + Quaternion.AngleAxis(-halfAngle, Vector3.up) * direction * radius;
        Vector3 rightVertex = transform.position + Quaternion.AngleAxis(halfAngle, Vector3.up) * direction * radius;

        // 绘制扇形的边缘线
        Handles.DrawLine(transform.position, leftVertex);
        Handles.DrawLine(transform.position, rightVertex);

        // 绘制扇形的弧线
        Handles.DrawWireArc(transform.position, Vector3.up, Quaternion.Euler(0, -halfAngle, 0) * direction, angle, radius);

    }
}
