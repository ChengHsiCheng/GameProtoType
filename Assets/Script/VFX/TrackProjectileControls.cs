using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class TrackProjectileControls : MonoBehaviour
{

    private float liveTime = 10;
    private float timer;
    private float moveSpeed = 1;
    private GameObject projectileTarget;
    private Vector3 projectileDir = Vector3.up;

    [SerializeField] private GameObject hitVFX;

    VisualEffect[] VFXs;

    private void Start()
    {
        VFXs = GetComponentsInChildren<VisualEffect>();

        projectileTarget = GameManager.player;
    }

    private void Update()
    {
        if (timer >= liveTime)
        {
            VFXCleaner();
        }

        timer += Time.deltaTime;

        projectileDir = projectileTarget.transform.position - transform.position;
        projectileDir.y = 0;

        transform.position += projectileDir * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hitVFX)
            return;

        Instantiate(hitVFX, transform.position, Quaternion.identity);
        VFXCleaner();
    }

    private void VFXCleaner()
    {
        foreach (VisualEffect vfx in VFXs)
        {
            vfx.Stop();
        }
        Destroy(gameObject);
    }

    public void SetValue(float liveTime, float moveSpeed, GameObject projectileTarget)
    {
        this.liveTime = liveTime;
        this.moveSpeed = moveSpeed;
        this.projectileTarget = projectileTarget;
    }
}