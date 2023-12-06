using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordControll : Riddle
{
    [SerializeField] Password[] passwords { get => GetComponentsInChildren<Password>(); }
    private string inputPassword;
    [SerializeField] string passOrder;

    private void OnEnable()
    {
        Reset();
    }

    private void Start()
    {
        GameManager.sceneController.UIInputReader.OnInteractiveEvent += Confirm;
        GameManager.sceneController.UIInputReader.OnResetEvent += Reset;
    }

    public void Confirm()
    {
        inputPassword = "";

        for (int i = 0; i < 5; i++)
        {
            inputPassword += passwords[i].numCount;
        }

        if (inputPassword == passOrder)
        {
            OnPass();
            audioLogic.PlayAudio("Success");
            return;
        }

        audioLogic.PlayAudio("Fail");
        Reset();
    }


    public void Reset()
    {
        for (int i = 0; i < passwords.Length; i++)
        {
            passwords[i].SetNum(0);
        }
    }

    public void ClickLock(Password password)
    {
        if (password.numCount < 9)
        {
            password.SetNum(password.numCount + 1);
        }
        else
        {
            password.SetNum(0);
        }
    }
}
