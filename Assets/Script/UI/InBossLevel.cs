using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBossLevel : MonoBehaviour
{
    [SerializeField] private int level;

    private void OnEnable()
    {
        GameManager.sceneController.UIInputReader.OnCheckEvent += EnterBossLevel;
    }

    private void OnDisable()
    {
        GameManager.sceneController.UIInputReader.OnCheckEvent -= EnterBossLevel;
    }

    private void EnterBossLevel()
    {
        switch (level)
        {
            case 1:
                GameManager.SwitchScene("Boss01Scenes");
                break;
            case 2:
                GameManager.SwitchScene("Boss02Scenes");
                break;
            case 3:
                GameManager.SwitchScene("Boss03Scenes");
                break;
        }
    }
}
