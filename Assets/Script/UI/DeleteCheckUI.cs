using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCheckUI : MonoBehaviour
{
    public void OnCancel()
    {
        GameManager.sceneController.UIController.CloseUI();
    }

    public void OnCover()
    {
        SaveSystem.DeleteData(GameManager.nowSavePath);
        GameManager.sceneController.UIController.CloseUI();
    }
}
