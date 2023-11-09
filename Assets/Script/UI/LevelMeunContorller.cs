using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelMeunContorller : UIManager
{
    [SerializeField] private GameObject[] levelBoss;
    private int count;

    private void OnEnable()
    {
        GameManager.sceneController.cinemachineController.SwitchCamera(CameraMode.ChooseLevel, levelBoss[0].transform);
    }

    private void OnDisable()
    {
        GameManager.sceneController.cinemachineController.SwitchCamera(CameraMode.Lobby);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            count = Mathf.Max(0, count - 1);
            GameManager.sceneController.cinemachineController.SwitchCamera(CameraMode.ChooseLevel, levelBoss[count].transform);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            count = Mathf.Min(levelBoss.Length - 1, count + 1);

            GameManager.sceneController.cinemachineController.SwitchCamera(CameraMode.ChooseLevel, levelBoss[count].transform);
        }
    }
}
