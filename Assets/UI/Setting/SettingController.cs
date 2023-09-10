using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class SettingController : MonoBehaviour
{
    [SerializeField] private Volume volume;
    private ColorAdjustments brightness;

    private void Start()
    {
        volume.profile.TryGet<ColorAdjustments>(out brightness);
    }

    public void SetBrightness(float volume)
    {
        brightness.postExposure.value = volume;
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

    public void SetFullScreen(bool isFullScreen)
    {
        GameManager.SetScreenMod(isFullScreen);
    }
}
