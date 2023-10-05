using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleManager : MonoBehaviour
{
    private Riddle[] riddles { get => GetComponentsInChildren<Riddle>(); }
    private RiddleController[] riddleControllers { get => GetComponentsInChildren<RiddleController>(); }

    private void OnEnable()
    {
        for (int i = 0; i < riddles.Length; i++)
        {
            riddles[i].OnPassEvent += PassEvent;
            riddleControllers[i].SetIsPass(riddleControllers[i].isPass);
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
}
