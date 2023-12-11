using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    private Text Text { get => GetComponent<Text>(); }
    [SerializeField] private string EnglishText;
    [SerializeField] private string ChineseText;

    private Image image { get => GetComponent<Image>(); }
    [SerializeField] private Sprite EnglishImage;
    [SerializeField] private Sprite ChineseImage;

    private void OnEnable()
    {
        GameManager.OnSwicthLanguage += SwicthLanguage;
    }

    private void Start()
    {
        SwicthLanguage();
    }

    private void OnDisable()
    {
        GameManager.OnSwicthLanguage -= SwicthLanguage;
    }

    public void SwicthLanguage()
    {
        Debug.Log(GameManager.language);

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
            }

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
            }
        }
    }
}
