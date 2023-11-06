using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Test : MonoBehaviour
{
    private void Update()
    {
        Quaternion targetRotation = Quaternion.Euler(0, 0, 45);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 20 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.SwitchScene("GameLobby");
        }
    }
}
