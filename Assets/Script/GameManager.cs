using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField] private GameObject player;
    [SerializeField] private SceneController sceneController;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (!sceneController)
        {
            sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
        }
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public SceneController GetSceneController()
    {
        return sceneController;
    }
}
