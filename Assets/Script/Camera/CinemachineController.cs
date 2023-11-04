using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineController : MonoBehaviour
{
    [field: SerializeField] public CinemachineVirtualCamera lobby { get; private set; }
    [field: SerializeField] public CinemachineVirtualCameraBase combat { get; private set; }
    [field: SerializeField] public CinemachineVirtualCameraBase initial { get; private set; }
    [field: SerializeField] public CinemachineVirtualCameraBase boss { get; private set; }
    [field: SerializeField] public CinemachineVirtualCameraBase level { get; private set; }

    bool isLobby;

    private void Start()
    {
        GameManager.sceneController.SetCinemachineController(this);

        isLobby = GameManager.nowScenes == "GameLobby";

        initial.VirtualCameraGameObject.SetActive(true);

        boss.VirtualCameraGameObject.SetActive(false);
        SwitchCamera();
    }

    public void BossCloseUp(GameObject _boss)
    {
        boss.LookAt = _boss.transform;
        combat.VirtualCameraGameObject.SetActive(false);
        lobby.VirtualCameraGameObject.SetActive(false);
        boss.VirtualCameraGameObject.SetActive(true);

        GameManager.sceneController.InputReader.enabled = false;
    }

    public void LevelCloseUp(GameObject obj)
    {
        lobby.LookAt = obj.transform;
        lobby.m_Lens.FieldOfView = 10;

        combat.VirtualCameraGameObject.SetActive(false);
        lobby.VirtualCameraGameObject.SetActive(true);
        boss.VirtualCameraGameObject.SetActive(false);

        GameManager.sceneController.InputReader.enabled = false;
    }


    public void BossDisCloseUp()
    {
        boss.LookAt = null;
        SwitchCamera();
        boss.VirtualCameraGameObject.SetActive(false);

        GameManager.sceneController.InputReader.enabled = true;
    }

    private void SwitchCamera()
    {
        combat.VirtualCameraGameObject.SetActive(!isLobby);
        lobby.VirtualCameraGameObject.SetActive(isLobby);

        initial.VirtualCameraGameObject.SetActive(false);
    }
}
