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
    [SerializeField] GameObject KeyPrompt;

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

        if (timer >= time)
        {
            timer = 0;
            count++;

            if (count == storyImage.Length)
            {
                isStarting = false;
                OnSwicthScene?.Invoke("GameLobby");
                GameManager.sceneController.UIInputReader.OnCheckEvent += NextImage;
                return;
            }

        }

        storyImage[count].color = new Color(1, 1, 1, MathF.Min(timer, 1));
    }

    public void OnStart()
    {
        isStarting = true;

        foreach (Image image in storyImage)
        {
            image.gameObject.SetActive(true);
        }

        KeyPrompt.SetActive(true);

        GameManager.sceneController.UIInputReader.OnCheckEvent += NextImage;
    }

    private void NextImage()
    {
        timer = time;
        storyImage[count].color = new Color(1, 1, 1, timer / (time / 2));
    }

}
