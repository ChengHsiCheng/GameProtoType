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
    [SerializeField] private CameraMode startMode = CameraMode.Initial;


    private void Start()
    {
        GameManager.sceneController.SetCinemachineController(this);

        if (GameManager.nowScenes == "GameLobby")
        {
            SwitchCamera(CameraMode.Lobby);
            Cameras[(int)CameraMode.ChooseLevel].LookAt = GameObject.Find("LevelUITrigger").transform;
            Cameras[(int)CameraMode.ChooseLevel].Follow = GameObject.Find("LevelUITrigger").transform;

        }
        else
        {
            SwitchCamera(startMode);
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
                Cameras[i].m_LookAt = null;
            }
        }

        StartCoroutine(SetInputReader(cameraMode));
    }

    private IEnumerator SetInputReader(CameraMode cameraMode)
    {
        // Debug.Log(cameraMode);

        yield return new WaitForSeconds(1f);

        if (cameraMode == CameraMode.BossStart || cameraMode == CameraMode.ChooseLevel || cameraMode == CameraMode.Initial)
        {
            GameManager.sceneController.InputReader.enabled = false;
            yield break;
        }

        if (GameManager.sceneController.UIInputReader.enabled == true)
            yield break;

        GameManager.sceneController.InputReader.enabled = true;
    }

}
