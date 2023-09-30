using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHendler : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioLogic[] logic;

    private void OnEnable()
    {
        for (int i = 0; i < logic.Length; i++)
        {
            logic[i].OnPlayAudio += PlayAudios;
            logic[i].OnPlayLoopAudio += StartAudios;
            logic[i].OnStopLoopAudio += StopAudios;
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < logic.Length; i++)
        {
            logic[i].OnPlayAudio -= PlayAudios;
            logic[i].OnPlayLoopAudio -= StartAudios;
            logic[i].OnStopLoopAudio -= StopAudios;
        }
    }

    private void PlayAudios(AudioClip clip)
    {
        source.PlayOneShot(clip);
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
}
