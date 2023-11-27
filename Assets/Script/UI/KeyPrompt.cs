using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPrompt : MonoBehaviour
{
    [SerializeField] private GameObject keyboard;
    [SerializeField] private GameObject gamePad;

    private void OnEnable()
    {
        GameManager.OnSwicthControlMethodEvent += SwicthControlMethod;
        SwicthControlMethod();
    }

    private void OnDisable()
    {
        GameManager.OnSwicthControlMethodEvent -= SwicthControlMethod;
    }

    private void SwicthControlMethod()
    {
        if (GameManager.controlMethod == ControlMethod.Keyboard)
        {
            keyboard?.SetActive(true);
            gamePad?.SetActive(false);
        }
        else
        {
            keyboard?.SetActive(false);
            gamePad?.SetActive(true);
        }
    }
}
