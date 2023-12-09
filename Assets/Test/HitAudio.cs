using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAudio : MonoBehaviour
{
    [SerializeField] private AudioLogic audioLogic;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audioLogic.PlayAudio("Hit");
        }
    }
}
