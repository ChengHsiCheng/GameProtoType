using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    public GameObject Frame;
    private Button button { get => GetComponent<Button>(); }
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

    public void ClickButton()
    {
        button.onClick.Invoke();
    }
}
