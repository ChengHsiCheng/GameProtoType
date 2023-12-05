using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelMeunContorller : UIManager
{
    private UIInputReader input;
    private Vector2 arrow;

    [SerializeField] private UIManager[] BossUIs;
    [SerializeField] private GameObject[] levelBoss;
    private int count;

    public override void OnOpen()
    {
        base.OnOpen();

        input = GameManager.sceneController.UIInputReader;

        GameManager.sceneController.cinemachineController.SwitchCamera(CameraMode.ChooseLevel, levelBoss[count].transform);

        input.OnArrowKeyEvent += ChooseLevel;
        input.OnCheckEvent += OnCheckLevel;
    }

    public override void OnClosure()
    {
        GameManager.sceneController.cinemachineController.SwitchCamera(CameraMode.Lobby);

        input.OnArrowKeyEvent -= ChooseLevel;
        input.OnCheckEvent -= OnCheckLevel;
    }

    public override void OnNext()
    {
        input.OnArrowKeyEvent -= ChooseLevel;
        input.OnCheckEvent -= OnCheckLevel;
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

    private void OnCheckLevel()
    {
        GameManager.sceneController.UIController.AddUI(BossUIs[count]);
    }
}
