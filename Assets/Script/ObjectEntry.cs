using System;
using UnityEngine;

[Serializable]
public struct ObjectEntry
{
    public string name;
    public GameObject gameObject;
}

[Serializable]
public struct AudioEntry
{
    public string name;
    public AudioClip[] audios;
    public float audioVolume;
}
