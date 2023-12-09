using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFadesOut : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float time;
    private float timer;


    // Update is called once per frame
    void Update()
    {
        if (GameManager.isPauseGame)
            return;

        timer += Time.deltaTime;
        audioSource.volume = 1 - timer / time;
    }
}
