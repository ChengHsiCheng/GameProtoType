using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialUI : UIManager
{

    private float Arrow;
    private float uiCount;
    [SerializeField] private GameObject[] uis;

    private void OnEnable()
    {
        GameManager.sceneController.UIInputReader.OnArrowKeyEvent += SwicthUI;

        for (int i = 0; i < uis.Length; i++)
        {
            if (i == uiCount)
            {
                uis[i].SetActive(true);
            }
            else
            {
                uis[i].SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        GameManager.sceneController.UIInputReader.OnArrowKeyEvent -= SwicthUI;
    }

    private void SwicthUI()
    {
        Arrow = GameManager.sceneController.UIInputReader.Arrow.x;
        uiCount += Arrow;

        if (uiCount == -1)
        {
            uiCount = uis.Length - 1;
        }

        if (uiCount == uis.Length)
        {
            uiCount = 0;
        }

        for (int i = 0; i < uis.Length; i++)
        {
            if (i == uiCount)
            {
                uis[i].SetActive(true);
            }
            else
            {
                uis[i].SetActive(false);
            }
        }
    }
}
