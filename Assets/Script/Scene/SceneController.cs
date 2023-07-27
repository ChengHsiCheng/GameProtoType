using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;

    private void Awake()
    {
        GameManager.sceneController = this;
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

    public void SetPauseMeun(bool isPause)
    {
        PauseMenu.SetActive(isPause);
    }
}
