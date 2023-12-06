using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    [field: SerializeField] public GameObject fire { get; private set; }
    [SerializeField] private int id;
    [SerializeField] private bool isOnClick = false;

    [SerializeField] private AudioLogic audioLogic;

    public event Action<string> OnCheckOrderEvent;

    void Start()
    {
        fire = transform.Find("Fire").gameObject;
    }

    public void OnClickKindleButton()
    {
        if (isOnClick)
            return;

        audioLogic.PlayAudio("Ignite");

        fire.gameObject.SetActive(true);

        OnCheckOrderEvent?.Invoke(id.ToString());

        isOnClick = true;
    }

    public void SetIsOnClick(bool value)
    {
        isOnClick = value;
    }
}
