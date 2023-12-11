using UnityEngine;
using UnityEngine.UI;

public class SetScreenModLanguage : MonoBehaviour
{
    private UnityEngine.UI.Dropdown dropdown { get => GetComponent<Dropdown>(); }
    [SerializeField] private Text text;
    [SerializeField] private string[] ChineseTexts;
    [SerializeField] private string[] EnglishTexts;

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
            for (int i = 0; i < dropdown.options.Count; i++)
            {
                dropdown.options[i].text = ChineseTexts[i];
            }

            text.font = GameManager.ChineseFont;
            dropdown.captionText.font = GameManager.ChineseFont;
            dropdown.captionText.text = ChineseTexts[dropdown.value];
        }
        else
        {
            for (int i = 0; i < dropdown.options.Count; i++)
            {
                dropdown.options[i].text = EnglishTexts[i];
            }

            text.font = GameManager.EnglishFont;
            dropdown.captionText.font = GameManager.EnglishFont;
            dropdown.captionText.text = EnglishTexts[dropdown.value];
        }
    }
}
