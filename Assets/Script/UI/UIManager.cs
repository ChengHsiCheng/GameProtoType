using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public GameObject firstSelected, lastSelected;

    public virtual void OnOpen()
    {
        EventSystem.current.SetSelectedGameObject(lastSelected == null ? firstSelected : lastSelected);
    }

    public virtual void OnClosure()
    {
        lastSelected = EventSystem.current.currentSelectedGameObject;
    }

    public virtual void OnNext()
    {
        lastSelected = EventSystem.current.currentSelectedGameObject;
    }
}
