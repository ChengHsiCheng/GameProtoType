using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Crown : MonoBehaviour
{
    public GameObject holder { get; private set; }
    private Health holderHealth;

    private PlayerStateMachine player;
    private EnemyInfo believer;

    private float timer;

    private void OnDisable()
    {
        believer.OnDie -= ChangeToPlayer;

        if (player)
            player.haveCrown = false;
    }

    private void Update()
    {
        if (holder)
            transform.position = holder.transform.position;

        holderHealth?.Healing(1 * Time.deltaTime);

        timer += Time.deltaTime;

        if (timer > 10)
        {
            Destroy(gameObject);
        }
    }

    public void SetCrownHolder(GameObject gameObject)
    {
        timer = 0;

        holder = gameObject;
        gameObject.TryGetComponent(out holderHealth);

        if (gameObject.tag == "Player")
        {
            player = gameObject.GetComponent<PlayerStateMachine>();
            player.haveCrown = true;
        }

        if (gameObject.tag == "Enemy")
        {
            believer = gameObject.GetComponent<EnemyInfo>();
            believer.OnDie += ChangeToPlayer;
            return;
        }

        believer.OnDie -= ChangeToPlayer;
    }

    private void ChangeToPlayer()
    {
        SetCrownHolder(GameManager.player);
    }
}
