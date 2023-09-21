using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KlotskiItem : MonoBehaviour
{
    public int id;
    public Text text;
    private void Start()
    {
        text.text = id.ToString();
    }
}
