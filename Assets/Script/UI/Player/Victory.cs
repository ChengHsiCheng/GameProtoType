using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] CanvasGroup Group;
    private float timer;
    private bool Show = true;

    private void Update()
    {
        if (Show)
        {
            timer += Time.deltaTime * 0.8f;

            if (timer >= 2)
                Show = false;
        }
        else
        {
            timer = MathF.Max(0, timer - Time.deltaTime * 0.8f);

            if (timer == 0)
            {
                Show = true;
                this.gameObject.SetActive(false);
            }
        }

        Group.alpha = timer;
    }
}
