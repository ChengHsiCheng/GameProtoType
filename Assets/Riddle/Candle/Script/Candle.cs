using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    public GameObject fire { get; private set; }
    [SerializeField] private int id;
    private bool isOnClick = false;

    public event Action<string> OnCheckOrderEvent;

    void Start()
    {
        fire = transform.Find("Fire").gameObject;
    }

    public void OnClickKindleButton()
    {
        if (isOnClick)
            return;

        fire.gameObject.SetActive(true);

        OnCheckOrderEvent?.Invoke(id.ToString());

        isOnClick = true;
    }

    public void SetIsOnClick(bool value)
    {
        isOnClick = value;
    }
}
