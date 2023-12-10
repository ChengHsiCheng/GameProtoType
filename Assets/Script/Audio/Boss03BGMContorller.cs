using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss03BGMContorller : MonoBehaviour
{
    [SerializeField] private AudioClip bgm01;
    [SerializeField] private AudioClip bgm02;
    [SerializeField] private AudioSource source;

    private float playTime;

    private void Start()
    {
        source.clip = bgm01;
        source.Play();
    }

    public void SwicthBGM()
    {
        playTime = source.time;

        source.clip = bgm02;
        source.Play();
        source.time = playTime;
    }
}
