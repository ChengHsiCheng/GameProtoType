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
        iFireBall.SetValue(fireBallSpeed, Vector3.up);
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
        Vector3 spawnPosition = new Vector3(randomPoint.x, 0f, randomPoint.y);
        spawnPosition.y = 20;

        ProjectileControls iFireBall = Instantiate(fireBall, spawnPosition, new Quaternion(0, 0, -90, 0));

        spawnPosition.y = 0;
        Instantiate(warningArea, spawnPosition, warningArea.transform.rotation);
        iFireBall.SetValue(fireBallSpeed, Vector3.down);
    }

}
