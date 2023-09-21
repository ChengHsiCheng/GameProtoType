using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hole : MonoBehaviour
{
    [SerializeField] private int count;
    public bool isMosaic { get; private set; }
    public bool isMerge { get; private set; }

    public event Action OnCheckEvent;

    public void OnMosaic(int i)
    {
        isMosaic = true;
        isMerge = (i == count);

        OnCheckEvent?.Invoke();
    }

    public void DisMosaic()
    {
        isMosaic = false;
    }

    public void OnReset()
    {
        isMosaic = false;
        isMerge = false;
    }

}
