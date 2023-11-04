using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIConntroller : InteractiveTrigger
{
    public override void OnInteractive()
    {
        GameManager.sceneController.cinemachineController.LevelCloseUp(this.gameObject);
    }
}
