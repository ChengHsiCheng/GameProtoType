using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : UIManager
{
    [SerializeField] Animator animator;
    [SerializeField] SettingController setting;
    [SerializeField] SlideshowContorller slideshow;

    string switchScene;

    private void OnEnable()
    {
        slideshow.OnSwicthScene += OnSwitchScene;
    }

    public void OnNewGmae()
    {
        slideshow.OnStart();
    }

    public void OnSwitchScene(string sceneName)
    {
        animator.SetTrigger("Switch");
        switchScene = sceneName;

        Debug.Log(switchScene);
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
