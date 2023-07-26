using System.Collections;
using System.Collections.Generic;
using UnityEngine.VFX;
using UnityEngine;

public class ProjectileControls : MonoBehaviour
{
    private float liveTime = 3;
    private float timer;
    private float moveSpeed = 1;
    private Vector3 projectileDir = Vector3.up;

    [SerializeField] private GameObject[] hitVFX;

    VisualEffect[] VFXs;

    private void Start()
    {
        VFXs = GetComponentsInChildren<VisualEffect>();
    }

    private void Update()
    {
        if (GameManager.isPauseGame)
            return;

        if (timer >= liveTime)
        {
            VFXCleaner();
        }

        timer += Time.deltaTime;

        transform.position += projectileDir * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hitVFX.Length == 0)
            return;

        for (int i = 0; i < hitVFX.Length; i++)
        {
            Instantiate(hitVFX[i], transform.position, Quaternion.identity);
        }
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

    public void SetValue(float liveTime, float moveSpeed, Vector3 projectileDir)
    {
        this.liveTime = liveTime;
        this.moveSpeed = moveSpeed;
        this.projectileDir = projectileDir;
    }
}
