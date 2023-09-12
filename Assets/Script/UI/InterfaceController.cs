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

    public void SetPauseMenu(bool active)
    {
        pauseMenu.gameObject.SetActive(active);
    }

    public void OnSetting()
    {
        setting.SetSettingUI(true);
    }
}
