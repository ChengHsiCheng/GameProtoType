using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Riddle : UIManager, IUIElement
{
    public event Action OnPassEvent;
    public UIManager hint;

    [SerializeField] protected AudioLogic audioLogic;

    public virtual void OnPass()
    {
        OnPassEvent?.Invoke();
        GameManager.sceneController.UIController.CloseUI();
    }

    public void OnQuit()
    {
        GameManager.sceneController.UIController.CloseUI();
    }

    public override void OnOpen()
    {
        base.OnOpen();

        audioLogic.PlayAudio("OpenRiddle");
        GameManager.sceneController.UIInputReader.OnPuzzleHintEvent += OpenPazzleHint;
    }

    public void OpenPazzleHint()
    {
        if (hint)
            GameManager.sceneController.UIController.AddUI(hint);
    }

    public override void OnClosure()
    {
        base.OnClosure();

        audioLogic.PlayAudio("ClosureRiddle");
        GameManager.sceneController.UIInputReader.OnPuzzleHintEvent -= OpenPazzleHint;
    }

    public override void OnNext()
    {
        base.OnNext();

        GameManager.sceneController.UIInputReader.OnPuzzleHintEvent -= OpenPazzleHint;
    }

}
