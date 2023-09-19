using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLogic : MonoBehaviour
{
    [SerializeField] List<AudioEntry> audios = new List<AudioEntry>();

    public event Action<AudioClip> OnPlayAudio;

    public void PlayAudio(string name)
    {
        OnPlayAudio?.Invoke(GetAudioByName(name));
    }

    // 使用名稱查找對應的物件
    private AudioClip GetAudioByName(string objectName)
    {
        AudioEntry entry = audios.Find(e => e.name == objectName);

        if (entry.audios != null)
        {
            if (entry.audios.Length == 0)
                return entry.audios[0];
            else
            {
                return entry.audios[UnityEngine.Random.Range(0, entry.audios.Length)];
            }
        }
        else
        {
            Debug.LogWarning("找不到名為 " + objectName + " 的物件。");
            return null;
        }
    }
}
