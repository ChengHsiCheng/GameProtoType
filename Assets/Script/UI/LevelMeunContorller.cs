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
    [SerializeField] private GameObject[] bossName;
    [SerializeField] private GameObject[] bossName_Chose;

    [SerializeField] private AudioLogic audioLogic;

    [SerializeField] private Transform aimPos;

    [SerializeField] private GameObject KeyPrompt;
    private int count;

    public override void OnOpen()
    {
        base.OnOpen();

        input = GameManager.sceneController.UIInputReader;

        GameManager.sceneController.cinemachineController.SwitchCamera(CameraMode.ChooseLevel, aimPos);

        KeyPrompt.SetActive(true);

        audioLogic.PlayAudio("OpenRiddle");

        for (int i = 0; i < bossName.Length; i++)
        {
            if (i == count)
            {
                bossName[i].SetActive(false);
                bossName_Chose[i].SetActive(true);
            }
            else
            {
                bossName[i].SetActive(true);
                bossName_Chose[i].SetActive(false);
            }
        }

        input.OnArrowKeyEvent += ChooseLevel;
        input.OnCheckEvent += OnCheckLevel;
    }

    public override void OnClosure()
    {
        GameManager.sceneController.cinemachineController.SwitchCamera(CameraMode.Lobby);

        KeyPrompt.SetActive(false);

        audioLogic.PlayAudio("ClosureRiddle");

        input.OnArrowKeyEvent -= ChooseLevel;
        input.OnCheckEvent -= OnCheckLevel;
    }

    public override void OnNext()
    {
        KeyPrompt.SetActive(false);

        input.OnArrowKeyEvent -= ChooseLevel;
        input.OnCheckEvent -= OnCheckLevel;
    }

    private void ChooseLevel()
    {
        arrow = input.Arrow;

        if (arrow.x == 1)
        {
            count = Mathf.Min(levelBoss.Length - 1, count + 1);
            // GameManager.sceneController.cinemachineController.SwitchCamera(CameraMode.ChooseLevel, levelBoss[count].transform);
        }
        else if (arrow.x == -1)
        {
            count = Mathf.Max(0, count - 1);
            // GameManager.sceneController.cinemachineController.SwitchCamera(CameraMode.ChooseLevel, levelBoss[count].transform);
        }

        for (int i = 0; i < bossName.Length; i++)
        {
            if (i == count)
            {
                bossName[i].SetActive(false);
                bossName_Chose[i].SetActive(true);
            }
            else
            {
                bossName[i].SetActive(true);
                bossName_Chose[i].SetActive(false);
            }
        }
    }

    private void OnCheckLevel()
    {
        Debug.Log(count);

        GameManager.sceneController.UIController.AddUI(BossUIs[count]);

        audioLogic.PlayAudio("OpenRiddle");
    }
}
