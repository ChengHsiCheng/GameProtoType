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

    public static string nowScene;

    public static bool isPauseGame = false;

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
}