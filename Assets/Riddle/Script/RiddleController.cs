using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleController : MonoBehaviour
{
    public bool isPass { private set; get; }

    [SerializeField] private UITrigger trigger;
    [SerializeField] private Riddle riddle { get => GetComponentInChildren<Riddle>(); }

    [SerializeField] private GameObject passedMode;
    [SerializeField] private GameObject originalMode;

    [SerializeField] private string riddleName;

    private void OnEnable()
    {
        riddle.OnPassEvent += PassEvent;
        riddle.gameObject.SetActive(false);
    }

    private void Start()
    {
        int isPass = SaveSystem.GetData(riddleName);

        if (isPass == 1)
        {
            PassEvent();
        }
        else
        {
            SetIsPass(false);
        }
    }

    private void PassEvent()
    {
        SetIsPass(true);
        trigger.DisableTrigger();

        SaveSystem.SaveData(riddleName, 1, GameManager.nowSavePath);
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
