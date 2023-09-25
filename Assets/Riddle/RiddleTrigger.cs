using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RiddleTrigger : MonoBehaviour
{
    [SerializeField] private Riddle riddle;
    [SerializeField] private Collider trigger;
    PlayerStateMachine player;

    private void Start()
    {
        player = GameManager.player.GetComponent<PlayerStateMachine>();
    }

    private void OnDisable()
    {
        if (player.Riddle == riddle)
        {
            player.SetRiddle(null);
            trigger.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.SetRiddle(riddle);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (player.Riddle == riddle)
            {
                player.SetRiddle(null);
            }
        }
    }
}
