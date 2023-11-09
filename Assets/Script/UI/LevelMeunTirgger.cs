using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMeunTirgger : InteractiveTrigger
{
    [SerializeField] private UIManager levelUI;

    public override void OnInteractive()
    {
        GameManager.sceneController.cinemachineController.SwitchCamera(CameraMode.ChooseLevel, this.transform);
        GameManager.sceneController.UIController.AddUI(levelUI);
    }
}
