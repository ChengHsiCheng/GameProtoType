using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class SettingController : UIManager
{
    [SerializeField] private Volume volume;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private GameObject settingUI;
    private ColorAdjustments brightness;

    private void Start()
    {
        volume.profile.TryGet<ColorAdjustments>(out brightness);
    }

    public void SetBrightness(float volume)
    {
        if (brightness)
            brightness.postExposure.value = volume;
    }

    public void SetAudioVolume(float volume)
    {
        mixer.SetFloat("AudioVolume", volume);
    }

    public void SetSettingUI(bool isActive)
    {
        settingUI.SetActive(isActive);
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
