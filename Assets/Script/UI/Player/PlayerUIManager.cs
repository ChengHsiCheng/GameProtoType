using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : UIManager
{
    [field: SerializeField] public BarController HpBar { get; private set; }
    [field: SerializeField] public BarController SanBar { get; private set; }
    [field: SerializeField] public UIManager DiedUI { get; private set; }
    [field: SerializeField] public Image HurtUI { get; private set; }
    [field: SerializeField] public Image LowSanUI { get; private set; }
    [field: SerializeField] public HintUI HintUI { get; private set; }
    [field: SerializeField] public GameObject HealUI { get; private set; }
    [field: SerializeField] public GameObject Victory { get; private set; }

    [SerializeField] private Text healCount;
    [SerializeField] private Text totalHealCount;

    [SerializeField] private float hurtUIAlphaDecayRate;
    private float hurtUIAlpha = 0;

    public bool isHint;

    private void Start()
    {
        GameManager.sceneController.UIController.OnOpenUIEvent += CloseHint;
        GameManager.sceneController.UIController.OnCloseUIEvent += OpenHint;

        if (GameManager.nowScenes != "GameLobby")
            return;

        HpBar.gameObject.SetActive(false);
        SanBar.gameObject.SetActive(false);
        HealUI.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        GameManager.sceneController.UIController.OnOpenUIEvent -= OpenHint;
        GameManager.sceneController.UIController.OnCloseUIEvent -= CloseHint;
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

    public void SetLowSanUI(float value)
    {
        LowSanUI.color = new Color(HurtUI.color.r, HurtUI.color.g, HurtUI.color.b, value);
    }

    public void SetDiedUI()
    {
        GameManager.sceneController.UIController.AddUI(DiedUI, false);

        StartCoroutine(SetUIInputReader());
    }

    private IEnumerator SetUIInputReader()
    {
        GameManager.sceneController.UIInputReader.enabled = false;
        yield return new WaitForSeconds(1f);
        GameManager.sceneController.UIInputReader.enabled = true;
        yield return null;
    }

    public void SetVictoryUI()
    {
        Victory.gameObject.SetActive(true);
    }

    public void OpenHint()
    {
        if (!isHint)
            return;

        SetHint(true);
    }

    public void CloseHint()
    {
        SetHint(false);
    }

    public void SetHint(bool value)
    {
        HintUI.gameObject.SetActive(value);
        HintUI.target = HintUI.gameObject;
    }

    public void SetHint(bool value, GameObject target)
    {
        HintUI.gameObject.SetActive(value);
        HintUI.target = target;
    }

    public void SetHealCountText(int _healCount, int _totalHealCount)
    {
        healCount.text = _healCount.ToString();
        totalHealCount.text = _totalHealCount.ToString();
    }
}
