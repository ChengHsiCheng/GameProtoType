using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class UITrigger : MonoBehaviour
{
    [SerializeField] private UIManager UI;
    [SerializeField] private Collider trigger;
    PlayerStateMachine player;

    private void Start()
    {
        player = GameManager.player.GetComponent<PlayerStateMachine>();
    }

    public void DisableTrigger()
    {
        trigger.enabled = false;
        player.RemoveUI(UI);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.AddUI(UI);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (player.UI.Count != 0)
            {
                player.RemoveUI(UI);
            }
        }
    }
}
