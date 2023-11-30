using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleControll : Riddle
{
    [SerializeField] private Candle[] candles { get => GetComponentsInChildren<Candle>(); }
    [SerializeField] private int passOrder;
    private int inputNum = 0;
    private string inputOrder;

    private void Start()
    {
        GameManager.sceneController.UIInputReader.OnResetEvent += TurnOff;
    }

    private void OnEnable()
    {
        TurnOff();
        for (int i = 0; i < candles.Length; i++)
        {
            candles[i].OnCheckOrderEvent += CheckOrder;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < candles.Length; i++)
        {
            candles[i].OnCheckOrderEvent -= CheckOrder;
        }
    }

    public void CheckOrder(string id)
    {
        inputOrder += id;
        inputNum++;
        if (inputNum == candles.Length)
        {
            if (inputOrder == passOrder.ToString())
            {
                OnPass();
                Debug.Log("PASS");
            }
            Invoke("TurnOff", 0.1f);
        }
    }

    public void TurnOff()
    {
        for (int i = 0; i < candles.Length; i++)
        {
            inputNum = 0;
            inputOrder = "";
            candles[i].fire.SetActive(false);
            candles[i].SetIsOnClick(false);
        }
    }

}
