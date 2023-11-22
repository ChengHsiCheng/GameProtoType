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

    private void OnDisable()
    {
        slideshow.OnSwicthScene -= OnSwitchScene;
    }

    private void Start()
    {
        GameManager.sceneController.UIController.AddUI(this);
        Debug.Log("ADD");
    }

    public void OnNewGmae()
    {
        slideshow.OnStart();
    }

    public void OnSwitchScene(string sceneName)
    {
        animator.SetTrigger("Switch");
        switchScene = sceneName;

    }

    public void OnSetting()
    {
        setting.OpenSetting();
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
