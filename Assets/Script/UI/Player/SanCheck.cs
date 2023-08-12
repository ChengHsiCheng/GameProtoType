using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanCheck : MonoBehaviour
{
    public RectTransform pointer01;
    public RectTransform pointer02;
    public Text text;

    private float counter;
    int ranStart;

    public event Action SuccessEvent;
    public event Action FailEvent;

    private void OnEnable()
    {
        ranStart = UnityEngine.Random.Range(0, 360);
        counter = 0;
        pointer01.localEulerAngles = new Vector3(0, 0, ranStart);
        pointer02.localEulerAngles = new Vector3(0, 0, ranStart);

        if (GameManager.controlMethod == ControlMethod.Keyboard)
        {
            text.text = "Press Space !!";
        }

        if (GameManager.controlMethod == ControlMethod.Gamepad)
        {
            text.text = "Press B !!";
        }
    }

    void Update()
    {
        if (counter >= 200)
        {
            FailEvent?.Invoke();
            return;
        }

        counter += 100 * Time.deltaTime;
        pointer01.localEulerAngles = new Vector3(0, 0, ranStart + counter);
        pointer02.localEulerAngles = new Vector3(0, 0, ranStart - counter);
    }

    public void OnCheck()
    {
        if (pointer01.eulerAngles.z > pointer02.eulerAngles.z - 20 && pointer01.eulerAngles.z < pointer02.eulerAngles.z + 20)
        {
            Debug.Log("S");
            SuccessEvent?.Invoke();
        }
        else
        {
            Debug.Log("F");
            FailEvent?.Invoke();
        }
    }
}
