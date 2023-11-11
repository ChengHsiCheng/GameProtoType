using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelMeunContorller : UIManager
{
    private UIInputReader input;
    private Vector2 arrow;

    [SerializeField] private GameObject[] levelBoss;
    private int count;

    private void OnEnable()
    {
        input = GameManager.sceneController.UIInputReader;

        GameManager.sceneController.cinemachineController.SwitchCamera(CameraMode.ChooseLevel, levelBoss[0].transform);

        input.OnArrowKeyEvent += ChooseLevel;
    }

    private void OnDisable()
    {
        GameManager.sceneController.cinemachineController.SwitchCamera(CameraMode.Lobby);

        input.OnArrowKeyEvent -= ChooseLevel;
    }

    private void ChooseLevel()
    {
        arrow = input.Arrow;

        if (arrow.x == 1)
        {
            count = Mathf.Min(levelBoss.Length - 1, count + 1);
            GameManager.sceneController.cinemachineController.SwitchCamera(CameraMode.ChooseLevel, levelBoss[count].transform);
        }
        else if (arrow.x == -1)
        {
            count = Mathf.Max(0, count - 1);
            GameManager.sceneController.cinemachineController.SwitchCamera(CameraMode.ChooseLevel, levelBoss[count].transform);
        }
    }
}
