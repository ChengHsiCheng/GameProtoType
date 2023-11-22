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

    private void Start()
    {
        volume.profile.TryGet<ColorAdjustments>(out brightness);

        brightnessSlider.value = GameManager.brightness;
        audioVolumeSlider.value = GameManager.audioVolume;

        SetBrightness(GameManager.brightness);
        SetAudioVolume(GameManager.audioVolume);

        GameManager.sceneController.UIInputReader.OnLeftTriggerEvent += SwitchLeftSetting;
        GameManager.sceneController.UIInputReader.OnRightTriggerEvent += SwitchRightSetting;
    }

    private void OnDisable()
    {

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
                GameManager.SetScreenResolution(2560, 1440);
                break;
            case 1:
                GameManager.SetScreenResolution(1920, 1080);
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
                GameManager.SetScreenMod(FullScreenMode.ExclusiveFullScreen);
                break;
            case 2:
                GameManager.SetScreenMod(FullScreenMode.Windowed);
                break;
            case 3:
                GameManager.SetScreenMod(FullScreenMode.MaximizedWindow);
                break;
        }
    }

    public void OpenSetting()
    {
        uiCount = 0;

        GameManager.sceneController.UIController.AddUI(settingUIs[uiCount]);
    }

    public void SwitchLeftSetting()
    {
        uiCount--;

        if (uiCount == -1)
        {
            uiCount = settingUIs.Length - 1;
        }

        UnityEngine.Debug.Log(uiCount);

        GameManager.sceneController.UIController.CloseUI();
        GameManager.sceneController.UIController.AddUI(settingUIs[uiCount]);
    }

    public void SwitchRightSetting()
    {
        uiCount++;

        if (uiCount == settingUIs.Length)
        {
            uiCount = 0;
        }

        UnityEngine.Debug.Log(settingUIs.Length);
        UnityEngine.Debug.Log(uiCount);

        GameManager.sceneController.UIController.CloseUI();
        GameManager.sceneController.UIController.AddUI(settingUIs[uiCount]);
    }
}
