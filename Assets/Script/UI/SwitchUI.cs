using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchUI : MonoBehaviour
{
    [field: SerializeField] public UIManager[] settingUIs { get; private set; }
    private int uiCount;

    [Obsolete]
    private void Start()
    {
        GameManager.sceneController.UIInputReader.OnLeftTriggerEvent += SwitchLeftSetting;
        GameManager.sceneController.UIInputReader.OnRightTriggerEvent += SwitchRightSetting;
    }

    [Obsolete]
    private void OnDisable()
    {
        GameManager.sceneController.UIInputReader.OnLeftTriggerEvent -= SwitchLeftSetting;
        GameManager.sceneController.UIInputReader.OnRightTriggerEvent -= SwitchRightSetting;
    }

    public void OpenUI()
    {
        uiCount = 0;

        GameManager.sceneController.UIController.AddUI(settingUIs[uiCount]);
    }

    [Obsolete]
    public void SwitchLeftSetting()
    {
        bool isOpen = false;

        for (int i = 0; i < settingUIs.Length; i++)
        {
            if (settingUIs[i].gameObject.active == true)
            {
                isOpen = true;
            }
        }

        if (!isOpen)
            return;

        uiCount--;

        if (uiCount == -1)
        {
            uiCount = settingUIs.Length - 1;
        }

        GameManager.sceneController.UIController.CloseUI();
        GameManager.sceneController.UIController.AddUI(settingUIs[uiCount]);
    }

    [Obsolete]
    public void SwitchRightSetting()
    {
        bool isOpen = false;

        for (int i = 0; i < settingUIs.Length; i++)
        {
            if (settingUIs[i].gameObject.active == true)
            {
                isOpen = true;
            }
        }

        if (!isOpen)
            return;

        uiCount++;

        if (uiCount == settingUIs.Length)
        {
            uiCount = 0;
        }

        GameManager.sceneController.UIController.CloseUI();
        GameManager.sceneController.UIController.AddUI(settingUIs[uiCount]);
    }
}
