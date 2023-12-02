using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02Soul : MonoBehaviour
{
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private float speed;

    private Boss02Altar altar { get => GameObject.FindAnyObjectByType<Boss02Altar>(); }

    private void Update()
    {
        transform.position += (targetPos - transform.position).normalized * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPos) <= 1)
        {
            ShieldBrokenCountReduced();
        }
    }

    private void ShieldBrokenCountReduced()
    {
        altar.ShieldBrokenCountReduced();

        Destroy(gameObject);
    }
}
