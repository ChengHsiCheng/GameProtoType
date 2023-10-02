using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Crown : MonoBehaviour
{
    public GameObject holder { get; private set; }
    private Health holderHealth;

    private PlayerStateMachine player;

    private float timer;

    private void OnDisable()
    {
        if (player)
            player.haveCrown = false;
    }

    private void Update()
    {
        if (holder)
            transform.position = holder.transform.position;

        holderHealth?.Healing(1);

        timer += Time.deltaTime;

        if (timer > 3)
        {
            Destroy(gameObject);
        }
    }

    public void SetCrownHolder(GameObject gameObject)
    {
        holder = gameObject;
        gameObject.TryGetComponent(out holderHealth);

        if (gameObject.tag == "Player")
        {
            player = gameObject.GetComponent<PlayerStateMachine>();
            player.haveCrown = true;
        }
    }
}
