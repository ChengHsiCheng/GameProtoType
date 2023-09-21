using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleTrigger : MonoBehaviour
{
    [SerializeField] private Riddle riddle;
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
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !riddle.isPass)
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
