using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveUI : MonoBehaviour
{
    public abstract void OnPress();
    public abstract void OnHold(Vector3 pos);
    public abstract void OnUnlash(GameObject gameObject);
}
