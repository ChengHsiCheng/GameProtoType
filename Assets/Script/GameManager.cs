using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.IO;

public enum ControlMethod
{
    Keyboard, Gamepad
}

public enum Languages
{
    English, Chinese
}


public static class GameManager
{
    public static GameObject player;
    public static SceneController sceneController; // 場景控制器
    public static List<Enemy> enemys = new List<Enemy>(); // 場上的敵人
    public static List<AudioHendler> audios = new List<AudioHendler>(); // 場上的敵人
    public static ControlMethod controlMethod; // 操控裝置
    public static Languages language;

    public static Font ChineseFont = Resources.Load<Font>("ChineseText");
    public static Font EnglishFont = Resources.Load<Font>("EnglishText");

    public static event Action OnSwicthControlMethodEvent;
    public static event Action OnSwicthLanguage;

    public static bool isPauseGame { private set; get; } = false; // 遊戲暫停
    public static bool isSetting { private set; get; } = false;
    public static string nowScenes { private set; get; } = SceneManager.GetActiveScene().name; // 目前場景
    public static string nextScenes { private set; get; }

    public static float brightness { private set; get; } // 亮度
    public static float audioVolume { private set; get; } = -10;  // 音量

    public static int screenHorizontal { private set; get; } // 螢幕大小_橫向
    public static int screenVertical { private set; get; } // 螢幕大小_縱向

    public static FullScreenMode screenMode { private set; get; } // 螢幕模式

    public static List<MainSaveData> mainSaveData;
    public static int nowSavePath;


    public static void TogglePause(bool isPause)
    {
        if (isSetting)
            return;

        isPauseGame = isPause;

        PauseGame();
    }

    static void PauseGame()
    {
        StateMachine[] stateMachines = GameObject.FindObjectsOfType<StateMachine>();

        foreach (StateMachine stateMachine in stateMachines)
        {
            stateMachine.OnGameTogglePause(isPauseGame);
        }

        VisualEffect[] vfxs = GameObject.FindObjectsOfType<VisualEffect>();

        foreach (VisualEffect vfx in vfxs)
        {
            vfx.pause = isPauseGame;
        }

        ParticleSystem[] particles = GameObject.FindObjectsOfType<ParticleSystem>();

        foreach (ParticleSystem particle in particles)
        {
            if (isPauseGame)
                particle.Pause();
            else
                particle.Play();
        }

        foreach (AudioHendler audio in audios)
        {
            if (isPauseGame)
                audio.PauseAudio();
            else
                audio.PauseEnded();
        }

        // AudioSource[] AudioSources = GameObject.FindObjectsOfType<AudioSource>();

        // foreach (AudioSource Sources in AudioSources)
        // {
        //     if (isPauseGame)
        //         Sources.Pause();
        //     else
        //         Sources.Play();
        // }

    }

    public static void SwitchScene(string scenesName)
    {
        nextScenes = scenesName;
        TogglePause(false);
        sceneController.UIController.CloseUI();
        SceneManager.LoadScene("Loading");
    }

    public static void SetNowScene(string scenesName)
    {
        nowScenes = scenesName;
    }

    public static void SetScreenMod(FullScreenMode _screenMode)
    {
        screenMode = _screenMode;
        Screen.fullScreenMode = screenMode;

        Debug.Log(screenMode);
    }

    public static void SetScreenResolution(int horizontal, int vertical)
    {
        Screen.SetResolution(horizontal, vertical, screenMode);
        screenHorizontal = horizontal;
        screenVertical = vertical;
    }

    public static void SetBrightness(float volume)
    {
        brightness = volume;
    }

    public static void SetAudioVolume(float volume)
    {
        audioVolume = volume;
    }

    public static void SetIsSetting(bool _isSetting)
    {
        isSetting = _isSetting;
    }

    public static void ToggleUI(bool value)
    {
        sceneController.InputReader.enabled = !value;
        sceneController.UIInputReader.enabled = value;
    }

    public static void SwitchControlMethod(ControlMethod _controlMethod)
    {
        controlMethod = _controlMethod;
        OnSwicthControlMethodEvent?.Invoke();
    }

    public static void SwitchLanguages(Languages _language)
    {
        language = _language;
        OnSwicthLanguage?.Invoke();
    }
}