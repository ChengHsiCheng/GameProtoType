using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public enum ControlMethod
{
    Keyboard, Gamepad
}


public static class GameManager
{
    public static GameObject player;
    public static SceneController sceneController; // 場景控制器
    public static List<Enemy> enemys = new List<Enemy>(); // 場上的敵人
    public static ControlMethod controlMethod; // 操控裝置


    public static bool isPauseGame { private set; get; } = false; // 遊戲暫停
    public static bool isSetting { private set; get; } = false;
    public static bool isRiddle { private set; get; } = false;
    public static string nowScenes { private set; get; } = SceneManager.GetActiveScene().name; // 目前場景

    public static float brightness { private set; get; } // 亮度
    public static float audioVolume { private set; get; }  // 音量

    public static int screenHorizontal { private set; get; } // 螢幕大小_橫向
    public static int screenVertical { private set; get; } // 螢幕大小_縱向

    public static FullScreenMode screenMode { private set; get; } // 螢幕模式

    public static void TogglePause()
    {
        if (isSetting)
            return;

        isPauseGame = !isPauseGame;

        PauseGame();
    }

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
    }

    public static void SwitchScene(string scenesName)
    {
        nowScenes = scenesName;
        SceneManager.LoadScene(scenesName);
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

        Debug.Log(screenHorizontal + " , " + screenVertical);
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

    public static void SetIsRiddle(bool value)
    {
        isRiddle = value;
    }

    public static void ToggleUI(bool value)
    {
        sceneController.InputReader.enabled = !value;
        sceneController.UIInputReader.enabled = value;
    }
}