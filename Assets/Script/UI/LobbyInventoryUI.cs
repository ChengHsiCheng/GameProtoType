using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class LobbyInventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject[] Inventorys;
    [SerializeField] private GameObject[] checkBoxs;
    [SerializeField] private UIManager[] puzzleHint;
    private int count;

    private void Start()
    {
        GameManager.sceneController.InputReader.InventoryUIControllerEvent += SelectNextItem;
        GameManager.sceneController.InputReader.HealEvent += OpenPuzzleHint;
    }

    private void OnEnable()
    {
        for (int i = 0; i < Inventorys.Length; i++)
        {
            if (count == i)
                checkBoxs[i].SetActive(true);
            else
                checkBoxs[i].SetActive(false);
        }
    }

    private void SelectNextItem(int value)
    {
        count -= value;

        if (count == -1)
            count = Inventorys.Length - 1;

        if (count == Inventorys.Length)
            count = 0;

        for (int i = 0; i < Inventorys.Length; i++)
        {
            if (count == i)
                checkBoxs[i].SetActive(true);
            else
                checkBoxs[i].SetActive(false);
        }
    }

    private void OpenPuzzleHint()
    {
        if (count < 3)
            GameManager.sceneController.UIController.AddUI(puzzleHint[count]);
    }
}
