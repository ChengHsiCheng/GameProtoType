using System.Diagnostics;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Unity.VisualScripting;


public class SettingController : MonoBehaviour
{
    [SerializeField] private Volume volume;
    [SerializeField] private AudioMixer mixer;
    [field: SerializeField] public UIManager[] settingUIs { get; private set; }
    private int uiCount;
    private ColorAdjustments brightness;

    [SerializeField] private Slider brightnessSlider;
    [SerializeField] private Slider audioVolumeSlider;
    private Dropdown screenResolution;
    private Dropdown screenMod;

    private void Start()
    {
        volume.profile.TryGet<ColorAdjustments>(out brightness);

        brightnessSlider.value = GameManager.brightness;
        audioVolumeSlider.value = GameManager.audioVolume;

        switch (GameManager.screenMode)
        {
            case FullScreenMode.FullScreenWindow:
                screenMod.value = 0;
                break;
            case FullScreenMode.MaximizedWindow:
                screenMod.value = 1;
                break;
            case FullScreenMode.Windowed:
                screenMod.value = 2;
                break;
        }

        switch (GameManager.screenHorizontal)
        {
            case 1280:
                screenResolution.value = 0;
                break;
            case 1920:
                screenResolution.value = 1;
                break;
            case 2560:
                screenResolution.value = 2;
                break;
        }

        switch (GameManager.screenMode)
        {
            case FullScreenMode.FullScreenWindow:
                screenMod.value = 0;
                break;
            case FullScreenMode.MaximizedWindow:
                screenMod.value = 1;
                break;
            case FullScreenMode.Windowed:
                screenMod.value = 2;
                break;
        }

        SetBrightness(GameManager.brightness);
        SetAudioVolume(GameManager.audioVolume);

        GameManager.sceneController.UIInputReader.OnLeftTriggerEvent += SwitchLeftSetting;
        GameManager.sceneController.UIInputReader.OnRightTriggerEvent += SwitchRightSetting;
    }

    private void OnDisable()
    {
        GameManager.sceneController.UIInputReader.OnLeftTriggerEvent -= SwitchLeftSetting;
        GameManager.sceneController.UIInputReader.OnRightTriggerEvent -= SwitchRightSetting;
    }

    public void SetBrightness(float volume)
    {
        GameManager.SetBrightness(volume);
        brightness.postExposure.value = GameManager.brightness;
    }

    public void SetAudioVolume(float volume)
    {
        if (volume <= -40)
            volume = -80;

        GameManager.SetAudioVolume(volume);
        mixer.SetFloat("AudioVolume", GameManager.audioVolume);
    }

    public void SetScreenResolution(int i)
    {
        switch (i)
        {
            case 0:
                GameManager.SetScreenResolution(1280, 720);
                break;
            case 1:
                GameManager.SetScreenResolution(1920, 1080);
                break;
            case 2:
                GameManager.SetScreenResolution(2560, 1440);
                break;
        }
    }

    public void SetScreenMod(int i)
    {
        switch (i)
        {
            case 0:
                GameManager.SetScreenMod(FullScreenMode.FullScreenWindow);
                break;
            case 1:
                GameManager.SetScreenMod(FullScreenMode.MaximizedWindow);
                break;
            case 2:
                GameManager.SetScreenMod(FullScreenMode.Windowed);
                break;
        }
    }

    public void OpenSetting()
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
