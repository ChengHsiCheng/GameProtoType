using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Riddle : UIManager, IUIElement
{
    public event Action OnPassEvent;

    [SerializeField] protected AudioLogic audioLogic;

    public virtual void OnPass()
    {
        OnPassEvent?.Invoke();
    }

    public void OnQuit()
    {
        GameManager.sceneController.UIController.CloseUI();
    }

    public override void OnOpen()
    {
        base.OnOpen();

        audioLogic.PlayAudio("OpenRiddle");
    }

    public override void OnClosure()
    {
        base.OnClosure();

        audioLogic.PlayAudio("ClosureRiddle");
    }

}
