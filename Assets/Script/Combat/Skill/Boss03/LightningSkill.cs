using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSkill : MonoBehaviour
{
    [field: SerializeField] public GameObject Lightningvfx { get; private set; }
    [field: SerializeField] public GameObject LightningWarningArea { get; private set; }

    Vector3 pos;
    private float timer;

    void Start()
    {
        pos = new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-15, 20));
        Instantiate(LightningWarningArea, pos + Vector3.up * 0.1f, Quaternion.identity);
    }

    void Update()
    {
        if (GameManager.isPauseGame)
            return;

        timer += Time.deltaTime;

        if (timer >= 0.9f)
        {
            Instantiate(Lightningvfx, pos, Quaternion.identity);
            Destroy(this);
        }

    }
}
