using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Riddle : MonoBehaviour
{
    public bool isPass { private set; get; }
    public event Action OnPassEvent;

    [SerializeField] protected GameObject passedMode;
    [SerializeField] protected GameObject originalMode;

    [SerializeField] private GameObject ui;
    [SerializeField] private RiddleTrigger trigger;

    public void SetUIActive(bool active)
    {
        ui.SetActive(active);
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

    public virtual void OnPass()
    {
        SetUIActive(false);

        SetIsPass(true);

        OnPassEvent?.Invoke();

        GameManager.TogglePause(false);

        GameManager.SetIsRiddle(false);

        trigger.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerStateMachine>();
        }
    }


    public void OnQuit()
    {
        SetUIActive(false);

        GameManager.TogglePause(false);

        GameManager.SetIsRiddle(false);
    }
}
