using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameoControll : Riddle
{
    [SerializeField] Hole[] holes { get => GetComponentsInChildren<Hole>(); }
    [SerializeField] Cameo[] cameos { get => GetComponentsInChildren<Cameo>(); }

    private void Start()
    {
        GameManager.sceneController.UIInputReader.OnResetEvent += Reset;
    }

    private void OnEnable()
    {
        for (int i = 0; i < holes.Length; i++)
        {
            holes[i].OnCheckEvent += CheckOrder;
        }

    }
    private void OnDisable()
    {
        for (int i = 0; i < holes.Length; i++)
        {
            holes[i].OnCheckEvent -= CheckOrder;
        }
    }

    public void CheckOrder()
    {
        bool isPass = true;

        foreach (Hole hole in holes)
        {
            if (!hole.isMosaic)
                return;
            if (!hole.isMerge)
                isPass = false;
        }

        if (isPass)
        {
            OnPass();
            audioLogic.PlayAudio("Success");
            return;
        }

        Reset();
        audioLogic.PlayAudio("Fail");
    }

    public void Reset()
    {
        foreach (Hole hole in holes)
        {
            hole.OnReset();
        }

        foreach (Cameo cameo in cameos)
        {
            cameo.OnReset();
        }

        audioLogic.PlayAudio("Return");
    }
}
