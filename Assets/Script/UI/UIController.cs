using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private UIInputReader inputReader;

    [SerializeField] public List<UIManager> UIElements { get; private set; } = new List<UIManager>();


    private void Start()
    {
        inputReader = GameManager.sceneController.UIInputReader;
        inputReader.OnBackEvent += CloseUI;
    }

    private void OnDisable()
    {
        inputReader.OnBackEvent -= CloseUI;
    }

    public void AddUI(UIManager ui)
    {
        AddUI(ui, true);
    }

    public void AddUI(UIManager ui, bool PauseGame)
    {
        if (UIElements.Count == 0)
        {
            GameManager.ToggleUI(true);
        }
        else
        {
            UIElements.Last()?.OnClosure();
        }

        if (!GameManager.isPauseGame && PauseGame)
        {
            GameManager.TogglePause(true);
        }

        UIElements.Add(ui);
        ui.gameObject.SetActive(true);

        ui.OnOpen();
    }

    public void CloseUI()
    {
        if (UIElements.Last().name == "MainMuen")
            return;

        UIElements.Last().OnClosure();
        UIElements.Last().gameObject.SetActive(false);
        UIElements.Remove(UIElements.Last());

        if (UIElements.Count == 0)
        {
            if (GameManager.isPauseGame)
            {
                GameManager.TogglePause(false);
            }
            GameManager.ToggleUI(false);
            return;
        }

        UIElements.Last().OnOpen();
    }
}
