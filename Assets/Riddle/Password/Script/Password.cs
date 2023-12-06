using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Password : MonoBehaviour
{
    [SerializeField] Text numText;
    public int numCount { get; private set; }

    [SerializeField] private AudioLogic audioLogic;
    void Start()
    {
        numCount = 0;
        numText = transform.Find("Text").gameObject.GetComponent<Text>();
    }

    public void SetNum(int value)
    {
        numCount = value;
        numText.text = numCount.ToString();

    }

    public void PlayAudio()
    {
        audioLogic.PlayAudio("Swicth");
    }

}
