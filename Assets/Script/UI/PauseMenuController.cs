using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : UIManager
{
    public Action onSettingEvent;
    public Action onTutorialEvent;

    public UIManager CreditsList;

    public void OnContinue()
    {
        GameManager.sceneController.UIController.CloseUI();
    }

    public void OnSetting()
    {
        onSettingEvent?.Invoke();
    }

    public void OnTutorial()
    {
        onTutorialEvent?.Invoke();
    }

    public void OnCreditsList()
    {
        GameManager.sceneController.UIController.AddUI(CreditsList);
    }

    public void OnMenu()
    {
        GameManager.SwitchScene("MainMenu");
    }

    public void OnTestScene()
    {
        GameManager.SwitchScene("Art VFX test");
    }
}
