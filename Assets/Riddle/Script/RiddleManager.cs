using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleManager : MonoBehaviour
{
    private Riddle[] riddles { get => GetComponentsInChildren<Riddle>(); }

    private void OnEnable()
    {
        for (int i = 0; i < riddles.Length; i++)
        {
            riddles[i].OnPassEvent += PassEvent;
            riddles[i].SetIsPass(riddles[i].isPass);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < riddles.Length; i++)
        {
            riddles[i].OnPassEvent -= PassEvent;
        }
    }

    private void PassEvent()
    {

    }

    public void OnOpenRiddle(Riddle riddle)
    {
        riddle.SetUIActive(true);
    }
}
