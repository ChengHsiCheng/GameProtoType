using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForceReceiver : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float drag = 0.3f; // impact的平滑過渡時間
    private Vector3 dempVelocity; // impact的平滑過渡速度
    private Vector3 impact; // impact的向量

    [SerializeField] public Vector3 Movement => impact; // 總運動向量，包括影響力和垂直速度的組合

    private void Update()
    {
        // 將impact進行平滑過渡，將其逐漸趨近於零
        impact = Vector3.SmoothDamp(impact, Vector3.zero, ref dempVelocity, drag);

        if (agent != null)
        {
            if (impact.sqrMagnitude < 0.2f * 0.2f)
            {
                impact = Vector3.zero;
                agent.enabled = true;
            }
        }
    }

    /// <summary>
    /// 施加外力
    /// </summary>
    /// <param name="force">向量</param>
    public void AddForce(Vector3 force)
    {
        impact += force;

        if (agent != null)
        {
            agent.enabled = false;
        }
    }
}
