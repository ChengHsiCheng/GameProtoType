using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public GameObject firstSelected, lastSelected;

    public void OnOpen()
    {
        EventSystem.current.SetSelectedGameObject(lastSelected == null ? firstSelected : lastSelected);
    }

    public void OnClosure()
    {
        lastSelected = EventSystem.current.currentSelectedGameObject;
        Debug.Log(EventSystem.current.currentSelectedGameObject);
    }
}
