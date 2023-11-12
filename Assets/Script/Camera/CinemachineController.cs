using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public enum CameraMode
{
    Initial, Lobby, Combat, BossStart, ChooseLevel
}

public class CinemachineController : MonoBehaviour
{

    [field: SerializeField] public CinemachineVirtualCamera[] Cameras { get; private set; }

    bool isLobby;

    private void Start()
    {
        GameManager.sceneController.SetCinemachineController(this);

        if (GameManager.nowScenes == "GameLobby")
        {
            SwitchCamera(CameraMode.Lobby);
        }
        else
        {
            SwitchCamera(CameraMode.Combat);
        }

    }

    public void SwitchCamera(CameraMode cameraMode)
    {
        SwitchCamera(cameraMode, GameManager.player.transform);
    }

    public void SwitchCamera(CameraMode cameraMode, Transform lookTarget)
    {
        for (int i = 0; i < Cameras.Length; i++)
        {
            if (i == (int)cameraMode)
            {
                Cameras[i].gameObject.SetActive(true);
                Cameras[i].m_LookAt = lookTarget;
            }
            else
            {
                Cameras[i].gameObject.SetActive(false);
            }
        }

        if (cameraMode == CameraMode.BossStart || cameraMode == CameraMode.ChooseLevel)
        {
            GameManager.sceneController.InputReader.enabled = false;
            return;
        }

        GameManager.sceneController.InputReader.enabled = true;

    }

}
