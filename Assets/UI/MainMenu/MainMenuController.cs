using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : UIManager
{
    [SerializeField] Animator animator;
    [SerializeField] SettingController setting;

    string switchScene;

    public void OnSwitchScene(string sceneName)
    {
        animator.SetTrigger("Switch");
        switchScene = sceneName;
    }

    public void OnSetting()
    {
        setting.SetSettingUI(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void SwitchScene()
    {
        GameManager.SwitchScene(switchScene);
    }
}
