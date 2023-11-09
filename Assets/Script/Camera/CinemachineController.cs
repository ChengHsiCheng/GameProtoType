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

                if (i == (int)CameraMode.BossStart)
                {
                    GameManager.sceneController.InputReader.enabled = false;
                }
                else
                {
                    GameManager.sceneController.InputReader.enabled = true;
                }
            }
            else
            {
                Cameras[i].gameObject.SetActive(false);
            }


        }
    }

    // public void BossCloseUp(GameObject _boss)
    // {
    //     boss.LookAt = _boss.transform;
    //     combat.VirtualCameraGameObject.SetActive(false);
    //     lobby.VirtualCameraGameObject.SetActive(false);
    //     boss.VirtualCameraGameObject.SetActive(true);

    //     GameManager.sceneController.InputReader.enabled = false;
    // }

    // public void LevelCloseUp(GameObject obj)
    // {
    //     lobby.LookAt = obj.transform;
    //     lobby.m_Lens.FieldOfView = 10;

    //     combat.VirtualCameraGameObject.SetActive(false);
    //     lobby.VirtualCameraGameObject.SetActive(true);
    //     boss.VirtualCameraGameObject.SetActive(false);

    //     GameManager.sceneController.InputReader.enabled = false;
    // }


    // public void BossDisCloseUp()
    // {
    //     boss.LookAt = null;
    //     SwitchCamera();
    //     boss.VirtualCameraGameObject.SetActive(false);

    //     GameManager.sceneController.InputReader.enabled = true;
    // }

}
