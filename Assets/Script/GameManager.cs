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
    public static List<Enemy> enemys = new List<Enemy>();
    public static ControlMethod controlMethod;

    public static string nowScene { private set; get; }

    public static int screenHorizontal { private set; get; }
    public static int screenVertical { private set; get; }

    public static bool isPauseGame { private set; get; } = false;
    public static bool isFullScreen { private set; get; } = false;

    public static void TogglePause()
    {
        isPauseGame = !isPauseGame;

        Debug.Log(isPauseGame);

        PauseGame();
    }

    public static void TogglePause(bool isPause)
    {
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

    public static void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        nowScene = sceneName;
    }

    public static void SetScreenMod(bool _isFullScreen)
    {
        isFullScreen = _isFullScreen;
        SetScreenResolution(screenHorizontal, screenVertical);

        Debug.Log(isFullScreen);
    }

    public static void SetScreenResolution(int horizontal, int vertical)
    {
        Screen.SetResolution(horizontal, vertical, isFullScreen);
        screenHorizontal = horizontal;
        screenVertical = vertical;

        Debug.Log(screenHorizontal + " , " + screenVertical);
    }
}