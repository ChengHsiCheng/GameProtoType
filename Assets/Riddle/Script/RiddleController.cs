using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleController : MonoBehaviour
{
    public bool isPass { private set; get; }

    [SerializeField] private RiddleTrigger trigger;
    [SerializeField] private Riddle riddle { get => GetComponentInChildren<Riddle>(); }

    [SerializeField] private GameObject passedMode;
    [SerializeField] private GameObject originalMode;

    private void OnEnable()
    {
        riddle.OnPassEvent += PassEvent;
        riddle.gameObject.SetActive(false);
        SetIsPass(false);
    }

    private void PassEvent()
    {
        SetIsPass(true);
        trigger.enabled = false;
        GameManager.sceneController.UIController.CloseUI();
    }

    public void SetIsPass(bool value)
    {
        isPass = value;
        ChangeMode();
    }

    private void ChangeMode()
    {
        passedMode?.SetActive(isPass);
        originalMode?.SetActive(!isPass);
    }
}
