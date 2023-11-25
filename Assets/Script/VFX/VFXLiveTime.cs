using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXLiveTime : MonoBehaviour
{
    [SerializeField] private float liveTime;
    private float timer;
    private bool isDestroy;

    [SerializeField] VisualEffect[] vfxs;
    [SerializeField] ParticleSystem[] particles;

    [SerializeField] Trigger trigger;

    private void Update()
    {
        if (GameManager.isPauseGame)
            return;

        timer += Time.deltaTime;

        if (timer >= liveTime)
        {
            Stop();
        }

    }

    public void SetLiveTime(float liveTime)
    {
        this.liveTime = liveTime;
    }

    public void Stop()
    {
        if (isDestroy)
            return;

        trigger?.Disable();

        foreach (VisualEffect vfx in vfxs)
        {
            vfx.Stop();
        }

        foreach (ParticleSystem particle in particles)
        {
            particle.Stop();
        }

        DestroyVFX(2f);

        isDestroy = true;
    }

    public void DestroyVFX()
    {
        Destroy(gameObject);
    }

    public void DestroyVFX(float time)
    {
        Destroy(gameObject, time);
    }

}
