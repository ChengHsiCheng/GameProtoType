using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FireBreathSkill : Skill
{
    [SerializeField] private ProjectileControls fireBall;
    [SerializeField] private GameObject warningArea;

    [SerializeField] private float fireBallSpeed;
    [SerializeField] private float radius;

    private float timer;
    private float count;

    public override void UseSkill()
    {
        ProjectileControls iFireBall = Instantiate(fireBall, transform.position, transform.rotation);
        iFireBall.SetValue(3, fireBallSpeed, Vector3.up);
    }

    public override void UseSkill(GameObject target)
    {
    }

    private void Update()
    {
        if (GameManager.isPauseGame)
            return;

        timer += Time.deltaTime;

        if (count == 0)
        {
            if (timer >= 3)
            {
                ShotFrieBall();
                count++;
                timer = 0;
            }
            return;
        }
        else if (count < 20)
        {
            if (timer >= 0.5f)
            {
                ShotFrieBall();
                count++;
                timer = 0;
            }
            return;
        }

        Destroy(gameObject);
    }

    private void ShotFrieBall()
    {
        // 圓形隨機範圍
        Vector2 randomPoint = Random.insideUnitCircle * radius;
        Debug.Log(randomPoint);
        Vector3 spawnPosition = new Vector3(randomPoint.x, 0f, randomPoint.y);
        spawnPosition.y = 20;

        ProjectileControls iFireBall = Instantiate(fireBall, spawnPosition, Quaternion.identity);

        spawnPosition.y = 0;
        Instantiate(warningArea, spawnPosition, warningArea.transform.rotation);
        iFireBall.SetValue(5, fireBallSpeed, Vector3.down);
    }

}
