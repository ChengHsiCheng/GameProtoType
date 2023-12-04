using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : UIManager
{
    [SerializeField] GameObject Boss01DieUI;
    [SerializeField] GameObject Boss02DieUI;
    [SerializeField] GameObject Boss03DieUI;
    [SerializeField] CanvasGroup Group;
    private float timer;

    private void OnEnable()
    {
        if (GameManager.nowScenes == "Boss01Scenes")
        {
            Boss01DieUI.SetActive(true);
            Boss02DieUI.SetActive(false);
            Boss03DieUI.SetActive(false);
        }
        else if (GameManager.nowScenes == "Boss02Scenes")
        {
            Boss01DieUI.SetActive(false);
            Boss02DieUI.SetActive(true);
            Boss03DieUI.SetActive(false);
        }
        else if (GameManager.nowScenes == "Boss03Scenes")
        {
            Boss01DieUI.SetActive(false);
            Boss02DieUI.SetActive(false);
            Boss03DieUI.SetActive(true);
        }

        GameManager.sceneController.UIInputReader.OnCheckEvent += TryAgain;
        GameManager.sceneController.UIInputReader.OnBackEvent += BackLobby;
    }

    private void OnDisable()
    {
        GameManager.sceneController.UIInputReader.OnCheckEvent -= TryAgain;
        GameManager.sceneController.UIInputReader.OnBackEvent -= BackLobby;
    }

    private void Update()
    {
        timer = MathF.Min(1, timer + Time.deltaTime);
        Group.alpha = timer;
    }

    public void TryAgain()
    {
        GameManager.SwitchScene(GameManager.nowScenes);
    }

    public void BackLobby()
    {
        GameManager.SwitchScene("GameLobby");
    }
}
