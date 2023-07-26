using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : UIManager
{
    [field: SerializeField] public BarController HpBar { get; private set; }
    [field: SerializeField] public BarController SanBar { get; private set; }
    [field: SerializeField] public SanCheck SanCheck { get; private set; }
    [field: SerializeField] public GameObject DiedUI { get; private set; }

    public void SetHpBar(float value)
    {
        HpBar.SetBar(value);
    }

    public void SetSanBar(float value)
    {
        SanBar.SetBar(value);
    }

    public void SetSanCheckBar(bool value)
    {
        SanCheck.gameObject.SetActive(value);
    }

    public void SetDiedUI(bool value)
    {
        DiedUI.SetActive(value);
    }
}
