using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
    [field: SerializeField] public bool IsInRadius { get; protected set; }
    protected bool isEnabled = true;

    public void Disable()
    {
        IsInRadius = false;
        isEnabled = false;
    }
}
