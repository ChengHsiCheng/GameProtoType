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
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < logic.Length; i++)
        {
            logic[i].OnPlayAudio -= PlayAudio;
        }
    }

    private void PlayAudio(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
