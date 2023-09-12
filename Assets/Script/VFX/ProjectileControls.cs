using System.Collections;
using System.Collections.Generic;
using UnityEngine.VFX;
using UnityEngine;

public class ProjectileControls : MonoBehaviour
{
    private float moveSpeed = 1;
    private Vector3 projectileDir;

    [SerializeField] private GameObject[] hitVFX;
    [SerializeField] private VFXLiveTime vfx;


    private void Update()
    {
        if (GameManager.isPauseGame)
            return;

        transform.position += projectileDir * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);

        if (hitVFX.Length == 0)
            return;

        Vector3 pos = transform.position;
        pos.y = 0;

        for (int i = 0; i < hitVFX.Length; i++)
        {
            Instantiate(hitVFX[i], pos, Quaternion.identity);
        }

        vfx.Stop();
    }

    public void SetValue(float moveSpeed, Vector3 projectileDir)
    {
        this.moveSpeed = moveSpeed;
        this.projectileDir = projectileDir;
    }
}
