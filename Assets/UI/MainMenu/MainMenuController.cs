using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : UIManager
{
    [SerializeField] Animator animator;
    [SerializeField] SettingController setting;
    [SerializeField] SlideshowContorller slideshow;
    [SerializeField] UIManager SaveUi;
    [SerializeField] UIManager LoadUi;

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
        GameManager.sceneController.UIController.AddUI(SaveUi);
    }

    public void OnContinue()
    {
        GameManager.sceneController.UIController.AddUI(LoadUi);
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
