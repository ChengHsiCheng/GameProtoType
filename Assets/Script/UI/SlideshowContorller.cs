using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class SlideshowContorller : MonoBehaviour
{
    [SerializeField] bool isStarting;
    [SerializeField] float time;
    float timer;
    int count;

    [SerializeField] Image[] storyImage;

    public Action<string> OnSwicthScene;

    private void Start()
    {
        foreach (Image image in storyImage)
        {
            image.color = new Color(1, 1, 1, 0);
        }
    }

    private void Update()
    {
        if (!isStarting)
            return;

        timer += Time.deltaTime;


        if (Input.GetMouseButtonDown(0))
        {
            timer = time;

            storyImage[count].color = new Color(1, 1, 1, timer / (time / 2));
        }

        if (timer >= time)
        {
            timer = 0;
            count++;

            if (count == storyImage.Length)
            {
                isStarting = false;
                OnSwicthScene?.Invoke("GameLobby");
                return;
            }
        }

        storyImage[count].color = new Color(1, 1, 1, timer / (time / 2));

    }

    public void OnStart()
    {
        isStarting = true;

        foreach (Image image in storyImage)
        {
            image.gameObject.SetActive(true);
        }
    }

}
