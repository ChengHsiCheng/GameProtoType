using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    [SerializeField] private Slider bar;

    public void SetBar(float value)
    {
        bar.value = value;
    }
}

