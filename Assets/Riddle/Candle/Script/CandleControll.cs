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

    private void OnEnable()
    {
        for (int i = 0; i < candles.Length; i++)
        {
            candles[i].OnCheckOrderEvent += CheckOrder;
        }

        SetUIActive(false);
    }

    private void OnDisable()
    {
        TurnOff();

        for (int i = 0; i < candles.Length; i++)
        {
            candles[i].OnCheckOrderEvent -= CheckOrder;
        }
    }

    public void CheckOrder(string id)
    {
        inputOrder += id;
        inputNum++;

        if (inputNum == 7)
        {
            if (inputOrder == passOrder.ToString())
            {
                OnPass();
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
