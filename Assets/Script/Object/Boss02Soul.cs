using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.VFX;

public class Boss02Soul : MonoBehaviour
{
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private float speed;
    private bool isBroken;

    [SerializeField] private VisualEffect soul;
    [SerializeField] private VisualEffect soulHit;

    private Boss02Altar altar { get => GameObject.FindAnyObjectByType<Boss02Altar>(); }

    private void Update()
    {
        if (GameManager.isPauseGame)
            return;

        transform.position += (targetPos - transform.position).normalized * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPos) <= 0.5f && !isBroken)
        {
            ShieldBrokenCountReduced();
            isBroken = true;
        }
    }

    private void ShieldBrokenCountReduced()
    {
        altar.ShieldBrokenCountReduced();

        soul.Stop();
        soulHit.gameObject.SetActive(true);
        soulHit.Play();

        Destroy(gameObject, 2);
    }
}
