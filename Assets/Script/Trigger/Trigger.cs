using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
    [field: SerializeField] public bool IsInRadius { get; protected set; }
}
