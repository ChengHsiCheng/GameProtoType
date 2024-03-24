using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    private Text Text { get => GetComponent<Text>(); }
    [SerializeField, MultilineAttribute(2)] private string EnglishText;
    [SerializeField, MultilineAttribute(2)] private string ChineseText;

    private Image image { get => GetComponent<Image>(); }
    [SerializeField] private Sprite EnglishImage;
    [SerializeField] private Sprite ChineseImage;

    [SerializeField] private GameObject EnglishObj;
    [SerializeField] private GameObject ChineseObj;

    private void OnEnable()
    {
        GameManager.OnSwicthLanguage += SwicthLanguage;
        SwicthLanguage();
    }

    private void OnDisable()
    {
        GameManager.OnSwicthLanguage -= SwicthLanguage;
    }

    public void SwicthLanguage()
    {
        if (GameManager.language == Languages.Chinese)
        {
            if (Text)
            {
                Text.text = ChineseText;
                Text.font = GameManager.ChineseFont;
                return;
            }

            if (image)
            {
                image.sprite = ChineseImage;
                return;
            }

            EnglishObj.SetActive(false);
            ChineseObj.SetActive(true);

        }
        else
        {
            if (Text)
            {
                Text.text = EnglishText;
                Text.font = GameManager.EnglishFont;
                return;
            }

            if (image)
            {
                image.sprite = EnglishImage;
                return;
            }

            EnglishObj.SetActive(true);
            ChineseObj.SetActive(false);
        }
    }
}
