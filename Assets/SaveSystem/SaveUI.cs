using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveUI : UIManager
{
    [SerializeField] private UIManager DeleteCheckUI;
    [SerializeField] private GameObject isSave00;
    [SerializeField] private GameObject isSave01;
    [SerializeField] private GameObject isSave02;

    public override void OnOpen()
    {
        base.OnOpen();

        SaveSystem.LoadData(0);
        if (SaveSystem.GetData("IsSave") == 1)
        {
            isSave00?.SetActive(true);
        }
        else
        {
            isSave00?.SetActive(false);
        }

        SaveSystem.LoadData(1);
        if (SaveSystem.GetData("IsSave") == 1)
        {
            isSave01?.SetActive(true);
        }
        else
        {
            isSave01?.SetActive(false);
        }

        SaveSystem.LoadData(2);
        if (SaveSystem.GetData("IsSave") == 1)
        {
            isSave02?.SetActive(true);
        }
        else
        {
            isSave02?.SetActive(false);
        }
    }

    public void OnLoad(int count)
    {
        SaveSystem.LoadData(count);

        GameManager.nowSavePath = count;

        if (SaveSystem.GetData("IsSave") != 1)
            return;

        GameManager.SwitchScene("GameLobby");
    }

    public void OnSave(int count)
    {
        GameManager.nowSavePath = count;

        SaveSystem.LoadData(count);

        if (SaveSystem.GetData("IsSave") == 1)
        {
            GameManager.sceneController.UIController.AddUI(DeleteCheckUI);
        }
        else
        {
            SaveSystem.SaveData("IsSave", 1, GameManager.nowSavePath);
            GameManager.SwitchScene("GameLobby");
        }
    }
}
