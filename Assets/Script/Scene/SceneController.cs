using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;

    private void Awake()
    {
        GameManager.sceneController = this;
    }

    public void SetPauseMeun(bool isPause)
    {
        PauseMenu.SetActive(isPause);
    }
}
