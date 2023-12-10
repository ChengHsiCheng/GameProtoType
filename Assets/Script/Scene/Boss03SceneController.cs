using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss03SceneController : SceneController
{
    [field: SerializeField] public Vector3[] Points { get; private set; }
    [SerializeField] private GameObject Palace_Blue;
    [SerializeField] private GameObject Palace_Red;
    [SerializeField] private Boss03BGMContorller boss03BGM;

    public void SwitchPalace(bool isBarrageState)
    {
        Palace_Blue.SetActive(isBarrageState);
        Palace_Red.SetActive(!isBarrageState);
        boss03BGM.SwicthBGM();
    }
}
