using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FireBreathSkill : Skill
{
    [SerializeField] private ProjectileControls fireBall;
    [SerializeField] private GameObject warningArea;

    [SerializeField] private float fireBallSpeed;

    private float timer;
    private float count;

    public override void UseSkill()
    {
        ProjectileControls iFireBall = Instantiate(fireBall, transform.position, transform.rotation);
        iFireBall.SetValue(3, fireBallSpeed, Vector3.up);
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
        float ranX = Random.Range(-20f, 20f);
        float ranZ = Random.Range(-20f, 20f);

        ProjectileControls iFireBall = Instantiate(fireBall, new Vector3(ranX, 20, ranZ), Quaternion.identity);
        Instantiate(warningArea, new Vector3(ranX, 0.1f, ranZ), warningArea.transform.rotation);
        iFireBall.SetValue(5, fireBallSpeed, Vector3.down);
    }

}
