using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private void Awake()
    {
        GameManager.sceneController = this;
    }
}
