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

    private void Update()
    {
        if (GameManager.isPauseGame)
            return;

        timer += Time.deltaTime;

        if (timer >= liveTime - 1)
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

        foreach (VisualEffect vfx in vfxs)
        {
            vfx.Stop();
        }

        foreach (ParticleSystem particle in particles)
        {
            particle.Stop();
        }

        Destroy(gameObject, 1f);

        isDestroy = true;
    }

}
