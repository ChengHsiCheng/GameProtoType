using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private UIInputReader inputReader;

    [SerializeField] private List<GameObject> UIElements = new List<GameObject>();
    [SerializeField] private SelectButton[] selectButtons;
    private SelectButton selectButton;

    [SerializeField] private int vertical;
    [SerializeField] private int horizontal;

    private void Start()
    {
        inputReader = GameManager.sceneController.UIInputReader;
        inputReader.OnBackEvent += CloseUI;
        inputReader.OnInteractiveEvent += ClickButton;
        inputReader.OnArrowKeyEvent += ChooseButton;
    }

    private void OnDisable()
    {
        inputReader.OnBackEvent -= CloseUI;
        inputReader.OnInteractiveEvent -= ClickButton;
        inputReader.OnArrowKeyEvent -= ChooseButton;
    }

    public void AddUI(GameObject ui)
    {
        AddUI(ui, true);
    }

    public void AddUI(GameObject ui, bool PauseGame)
    {
        if (UIElements.Count == 0)
        {
            GameManager.ToggleUI(true);
        }

        if (!GameManager.isPauseGame && PauseGame)
        {
            GameManager.TogglePause(true);
        }

        selectButtons = ui.transform.GetComponentsInChildren<SelectButton>();

        if (selectButtons.Length != 0)
        {
            vertical = 0;
            horizontal = 0;
            selectButton = selectButtons[0];
            selectButton.OnSelect();
        }

        UIElements.Add(ui);
        ui.SetActive(true);
    }

    public void CloseUI()
    {
        UIElements.Last().SetActive(false);
        UIElements.Remove(UIElements.Last());

        if (UIElements == null)
        {
            if (GameManager.isPauseGame)
            {
                GameManager.TogglePause(false);
            }
            GameManager.ToggleUI(false);

            return;
        }

        selectButtons = UIElements.Last().transform.GetComponentsInChildren<SelectButton>();

        foreach (SelectButton _selectButton in selectButtons)
        {
            _selectButton.OnDisSelect();
        }

        if (selectButtons.Length != 0)
        {
            vertical = 0;
            horizontal = 0;
            selectButton = selectButtons[0];
            selectButton.OnSelect();
        }
    }

    public void ClickButton()
    {
        Debug.Log("B");

        selectButton?.ClickButton();
    }

    public void ChooseButton()
    {
        vertical += (int)inputReader.Arrow.y;
        horizontal += (int)inputReader.Arrow.x;

        for (int i = 0; i < selectButtons.Length; i++)
        {
            if (vertical == selectButtons[i].vertical && horizontal == selectButtons[i].horizontal)
            {
                selectButton.OnDisSelect();
                selectButton = selectButtons[i];
                selectButton.OnSelect();

                Debug.Log("S");
                return;
            }
        }

        vertical -= (int)inputReader.Arrow.y;
        horizontal -= (int)inputReader.Arrow.x;
    }
}
