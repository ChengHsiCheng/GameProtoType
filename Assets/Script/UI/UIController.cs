using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private UIInputReader inputReader;

    [SerializeField] private List<GameObject> UIElements = new List<GameObject>();

    private void Start()
    {
        inputReader = GameManager.sceneController.UIInputReader;
        inputReader.OnBackEvent += CloseUI;
    }

    public void AddUI(GameObject ui)
    {
        if (UIElements.Count == 0)
        {
            GameManager.ToggleUI(true);
        }

        if (!GameManager.isPauseGame)
        {
            GameManager.TogglePause(true);
        }

        UIElements.Add(ui);
        ui.SetActive(true);
    }

    public void CloseUI()
    {

        UIElements[UIElements.Count - 1].SetActive(false);
        UIElements.RemoveAt(UIElements.Count - 1);

        if (UIElements.Count != 0)
            return;

        GameManager.ToggleUI(false);

        if (GameManager.isPauseGame)
        {
            GameManager.TogglePause(false);
        }

    }
}
