using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{
    [SerializeField] private PauseMenuController pauseMenu;
    [SerializeField] private SettingController setting;
    [SerializeField] private SwitchUI tutorialUI;

    private void OnEnable()
    {
        pauseMenu.onSettingEvent += OnSetting;
        pauseMenu.onTutorialEvent += OnTutorial;
    }

    private void OnDisable()
    {
        pauseMenu.onSettingEvent -= OnSetting;
        pauseMenu.onTutorialEvent -= OnTutorial;
    }

    public void OnPauseMenu()
    {
        GameManager.sceneController.UIController.AddUI(pauseMenu);
    }

    public void OnSetting()
    {
        setting.OpenSetting();
    }

    public void OnTutorial()
    {
        tutorialUI.OpenUI();
    }
}
