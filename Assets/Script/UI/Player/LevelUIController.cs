using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIController : MonoBehaviour
{
    [SerializeField] private GameObject[] levelIntroduction;

    public void ChangeLevel(int count)
    {
        var buttion = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        buttion.transform.SetAsLastSibling();
        for (int i = 0; i < levelIntroduction.Length; i++)
        {
            if (i == count - 1)
            {
                levelIntroduction[i].SetActive(true);
            }
            else
            {
                levelIntroduction[i].SetActive(false);
            }
        }
    }

    public void OnStart(string scenesName)
    {
        GameManager.SwitchScene(scenesName);
    }

    public void OnQuit()
    {
        GameManager.sceneController.UIController.CloseUI();
    }

}
