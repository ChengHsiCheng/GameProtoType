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

    private void Start()
    {
        Debug.Log(SaveSystem.GetData("isTutorial"));
        if (SaveSystem.GetData("isTutorial") != 1)
        {
            OnTutorial();
            SaveSystem.SaveData("isTutorial", 1, GameManager.nowSavePath);
        }
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
        Debug.Log("ASD");
        tutorialUI.OpenUI();
    }
}
