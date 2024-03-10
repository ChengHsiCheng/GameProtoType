using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public event Action OnOpenUIEvent;
    public event Action OnCloseUIEvent;
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
        // Debug.Log(ui);

        if (UIElements.Count == 0)
        {
            GameManager.ToggleUI(true);

            if (GameManager.controlMethod == ControlMethod.Keyboard)
                Cursor.visible = true;

            OnOpenUIEvent?.Invoke();
        }
        else
        {
            UIElements.Last()?.OnNext();
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
        if (UIElements.Count == 0)
        {
            return;
        }

        if (UIElements.Last().name == "MainMuen")
            return;

        if (UIElements.Last().name == "GameOver")
            return;

        if (UIElements.Last().name == "StorySlideshow")
            return;

        UIElements.Last().OnClosure();
        UIElements.Last().gameObject.SetActive(false);
        UIElements.Remove(UIElements.Last());

        if (UIElements.Count == 0)
        {
            Cursor.visible = false;

            OnCloseUIEvent?.Invoke();

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
