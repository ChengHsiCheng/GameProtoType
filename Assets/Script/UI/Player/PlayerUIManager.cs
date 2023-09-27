using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : UIManager
{
    [field: SerializeField] public BarController HpBar { get; private set; }
    [field: SerializeField] public BarController SanBar { get; private set; }
    [field: SerializeField] public SanCheck SanCheck { get; private set; }
    [field: SerializeField] public GameObject DiedUI { get; private set; }
    [field: SerializeField] public Image HurtUI { get; private set; }

    [SerializeField] private float hurtUIAlphaDecayRate;
    private float hurtUIAlpha = 0;

    private void Start()
    {
        if (GameManager.nowScenes == "GameLobby")
            gameObject.SetActive(false);
    }

    private void Update()
    {
        if (HurtUI.color.a != 0)
        {
            hurtUIAlpha = Mathf.Max(hurtUIAlpha - Time.deltaTime * hurtUIAlphaDecayRate, 0);
            float a = hurtUIAlpha / 255;
            HurtUI.color = new Color(HurtUI.color.r, HurtUI.color.g, HurtUI.color.b, a);
        }
    }

    public void BeAttack()
    {
        hurtUIAlpha = Mathf.Min(hurtUIAlpha + 60, 255);
        float a = hurtUIAlpha / 255;
        HurtUI.color = new Color(HurtUI.color.r, HurtUI.color.g, HurtUI.color.b, a);
    }

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

    public void SetDiedUI()
    {
        GameManager.sceneController.UIController.AddUI(DiedUI, false);
    }
}
