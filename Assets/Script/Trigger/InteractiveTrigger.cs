using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveTrigger : MonoBehaviour
{
    PlayerStateMachine player;

    private void Start()
    {
        player = GameManager.player.GetComponent<PlayerStateMachine>();
    }

    public abstract void OnInteractive();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.Interactiveobj.Add(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player.Interactiveobj.Remove(this);
        }
    }
}
