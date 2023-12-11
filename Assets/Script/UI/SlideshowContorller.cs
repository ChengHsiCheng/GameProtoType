using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class SlideshowContorller : UIManager
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

        if (count == storyImage.Length - 1)
        {
            if (timer >= 2)
            {
                isStarting = false;
                OnSwicthScene?.Invoke("GameLobby");
                GameManager.sceneController.UIInputReader.OnCheckEvent += NextImage;
                return;
            }
        }

        if (timer >= time)
        {
            timer = 0;
            count++;
        }

        storyImage[count].color = new Color(1, 1, 1, MathF.Min(timer, 1));
    }

    public void OnStart()
    {
        isStarting = true;

        GameManager.sceneController.UIController.AddUI(this);

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
