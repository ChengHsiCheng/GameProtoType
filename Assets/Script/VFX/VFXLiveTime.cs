using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXLiveTime : MonoBehaviour
{
    [SerializeField] private float liveTime;
    private float timer;

    private void Update()
    {
        if (GameManager.isPauseGame)
            return;

        timer += Time.deltaTime;


        if (timer >= liveTime)
        {
            Destroy(gameObject);
        }
    }
}
