using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class SettingController : UIManager
{
    [SerializeField] private Volume volume;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private GameObject settingUI;
    private ColorAdjustments brightness;

    [SerializeField] private Slider brightnessSlider;
    [SerializeField] private Slider audioVolumeSlider;

    private void Start()
    {
        volume.profile.TryGet<ColorAdjustments>(out brightness);

        SetBrightness(GameManager.brightness);
        SetAudioVolume(GameManager.audioVolume);

        brightnessSlider.value = GameManager.brightness;
        audioVolumeSlider.value = GameManager.audioVolume;
    }

    public void SetBrightness(float volume)
    {
        GameManager.SetBrightness(volume);
        brightness.postExposure.value = GameManager.brightness;
    }

    public void SetAudioVolume(float volume)
    {
        GameManager.SetAudioVolume(volume);
        mixer.SetFloat("AudioVolume", GameManager.audioVolume);
    }

    public void SetSettingUI(bool isActive)
    {
        settingUI.SetActive(isActive);

        GameManager.SetIsSetting(isActive);
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
}
