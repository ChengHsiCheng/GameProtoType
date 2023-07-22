using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FireBreathSkill : Skill
{
    [SerializeField] private ProjectileControls fireBall;
    [SerializeField] private GameObject warningArea;

    [SerializeField] private float fireBallSpeed;

    private void Start()
    {
        StartCoroutine(FireBallRain());

        ProjectileControls iFireBall = Instantiate(fireBall, transform.position, transform.rotation);
        iFireBall.SetValue(3, fireBallSpeed, Vector3.up);
    }

    public override void UseSkill()
    {
        StartCoroutine(FireBallRain());

        ProjectileControls iFireBall = Instantiate(fireBall, transform.position, transform.rotation);
        iFireBall.SetValue(3, fireBallSpeed, Vector3.up);
    }

    IEnumerator FireBallRain()
    {
        yield return new WaitForSeconds(3);

        for (int i = 0; i < 20; i++)
        {
            float ranX = Random.Range(-20f, 20f);
            float ranZ = Random.Range(-20f, 20f);

            ProjectileControls iFireBall = Instantiate(fireBall, new Vector3(ranX, 20, ranZ), Quaternion.identity);
            Instantiate(warningArea, new Vector3(ranX, 0.1f, ranZ), warningArea.transform.rotation);
            iFireBall.SetValue(5, fireBallSpeed, Vector3.down);

            yield return new WaitForSeconds(0.5f);
        }

        Destroy(gameObject);

    }

}
