using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    [SerializeField] private Image fill;

    public void SetBar(float value)
    {
        fill.fillAmount = value;
    }
}

