using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    public static GameObject player;
    public static SceneController sceneController; // 場景控制器
    public static List<Enemy> enemys = new List<Enemy>();
}

/*
public static class GameManager : MonoBehaviour
{
    private static GameManager instance; // 場景上的GameManager

    [SerializeField] private GameObject player;
    [SerializeField] private SceneController sceneController; // 場景控制器

    private void Awake()
    {
        // 切換場景時不會被刪除
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
        // 切換場景時取得場景上的Player跟SceneController
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (!sceneController)
        {
            sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
        }
    }

    /// <summary>
    /// 取得GameManager物件
    /// </summary>
    public static GameManager GetInstance()
    {
        return instance;
    }

    /// <summary>
    /// 取得Player物件
    /// </summary>
    public GameObject GetPlayer()
    {
        return player;
    }

    /// <summary>
    /// 取得SceneController物件
    /// </summary>
    public SceneController GetSceneController()
    {
        return sceneController;
    }
}*/
