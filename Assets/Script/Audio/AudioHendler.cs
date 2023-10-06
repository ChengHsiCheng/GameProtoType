using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHendler : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioLogic[] logic;

    private float audioTime;
    private AudioClip pauseAudio;

    private void OnEnable()
    {
        for (int i = 0; i < logic.Length; i++)
        {
            logic[i].OnPlayAudio += PlayAudios;
            logic[i].OnPlayLoopAudio += StartAudios;
            logic[i].OnStopLoopAudio += StopAudios;
        }

        GameManager.audios.Add(this);
    }

    private void OnDestroy()
    {
        for (int i = 0; i < logic.Length; i++)
        {
            logic[i].OnPlayAudio -= PlayAudios;
            logic[i].OnPlayLoopAudio -= StartAudios;
            logic[i].OnStopLoopAudio -= StopAudios;
        }

        GameManager.audios.Remove(this);
    }

    private void PlayAudios(AudioClip clip)
    {
        source.PlayOneShot(clip);
        pauseAudio = clip;
    }

    private void StartAudios(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }

    private void StopAudios()
    {
        source.clip = null;
    }

    public void PauseAudio()
    {
        audioTime = source.time;
        source.Pause();
    }

    public void PauseEnded()
    {
        source.PlayOneShot(pauseAudio, audioTime);
    }
}
