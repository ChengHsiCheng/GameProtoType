using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{
    [SerializeField] private PauseMenuController pauseMenu;
    [SerializeField] private SettingController setting;

    private void OnEnable()
    {
        pauseMenu.onSettingEvent += OnSetting;
    }

    public void OnPauseMenu()
    {
        GameManager.sceneController.UIController.AddUI(pauseMenu);
    }

    public void OnSetting()
    {
        setting.OpenSetting();
    }
}
