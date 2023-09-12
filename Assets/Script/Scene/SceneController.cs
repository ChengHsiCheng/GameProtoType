using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    private void Awake()
    {
        GameManager.sceneController = this;
        Application.targetFrameRate = 60;
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
