using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public InputReader InputReader { get; private set; }
    public UIInputReader UIInputReader { get; private set; }
    public UIController UIController { get; private set; }


    private void OnEnable()
    {
        GameManager.sceneController = this;

        InputReader = this.AddComponent<InputReader>();
        UIInputReader = this.AddComponent<UIInputReader>();
        UIController = this.AddComponent<UIController>();

        UIInputReader.enabled = false;
    }

    private void Awake()
    {
        Application.targetFrameRate = 120;
    }

    private void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
        SceneManager.sceneUnloaded += SceneUnloaded;
    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("SceneLoaded");
    }

    private void SceneUnloaded(Scene scene)
    {
        GameManager.enemys.Clear();
    }

}
