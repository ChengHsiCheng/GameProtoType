using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHint : MonoBehaviour
{
    [SerializeField] private AudioLogic audioLogic;

    private void OnEnable()
    {
        audioLogic.PlayAudio("Open");
    }

    private void OnDisable()
    {
        audioLogic.PlayAudio("Closed");
    }
}
