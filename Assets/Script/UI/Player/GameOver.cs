using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : UIManager
{
    public void TryAgain()
    {
        GameManager.SwitchScene(GameManager.nowScenes);
    }

    public void BackLobby()
    {
        GameManager.SwitchScene("GameLobby");
    }
}
