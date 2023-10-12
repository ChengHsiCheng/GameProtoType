using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public GameObject Frame;
    [field: SerializeField] public int horizontal { get; private set; }
    [field: SerializeField] public int vertical { get; private set; }

    public void OnSelect()
    {
        Frame.SetActive(true);

        Debug.Log("Select");
    }

    public void OnDisSelect()
    {
        Frame.SetActive(false);

        Debug.Log("DisSelect");

    }
}
