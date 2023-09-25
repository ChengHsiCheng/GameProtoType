using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Riddle : MonoBehaviour
{
    public event Action OnPassEvent;

    public virtual void OnPass()
    {
        OnPassEvent?.Invoke();
    }

    public void OnQuit()
    {
        GameManager.sceneController.UIController.CloseUI();
    }
}
