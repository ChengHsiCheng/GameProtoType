using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMuenController : MonoBehaviour
{
    [SerializeField] Animator animator;

    string switchScene;

    public void OnSwitchScene(string sceneName)
    {
        animator.SetTrigger("Switch");
        switchScene = sceneName;
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
