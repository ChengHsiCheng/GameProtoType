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
            logic[i].OnPlayAudio += PlayAudio;
            logic[i].OnPlayLoopAudio += StartAudio;
            logic[i].OnStopLoopAudio += StopAudio;
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < logic.Length; i++)
        {
            logic[i].OnPlayAudio -= PlayAudio;
            logic[i].OnPlayLoopAudio -= StartAudio;
            logic[i].OnStopLoopAudio -= StopAudio;
        }
    }

    private void PlayAudio(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }

    private void StartAudio(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }

    private void StopAudio()
    {
        source.clip = null;
    }
}
