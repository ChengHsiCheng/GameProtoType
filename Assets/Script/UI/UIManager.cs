using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private float planeDir;

    private Canvas canvas
    {
        get => this.GetComponent<Canvas>();
    }

    private void OnEnable()
    {
        canvas.worldCamera = Camera.main;
        canvas.planeDistance = planeDir;
    }
}
