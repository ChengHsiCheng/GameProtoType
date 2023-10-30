using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Riddle : UIManager, IUIElement
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
