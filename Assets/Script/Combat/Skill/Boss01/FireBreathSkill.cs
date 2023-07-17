using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FireBreathSkill : Skill
{
    [SerializeField] private ProjectileControls fireBall;

    void Start()
    {
        StartCoroutine(FireBallRain());

        ProjectileControls iFireBall = Instantiate(fireBall, transform.position, transform.rotation);
        iFireBall.SetValue(3, 10, Vector3.up);
    }

    IEnumerator FireBallRain()
    {
        yield return new WaitForSeconds(3);

        for (int i = 0; i < 20; i++)
        {
            float ranX = Random.Range(-20f, 20f);
            float ranZ = Random.Range(-20f, 20f);

            ProjectileControls iFireBall = Instantiate(fireBall, new Vector3(ranX, 20, ranZ), Quaternion.Euler(0, 0, transform.rotation.z + 180));
            iFireBall.SetValue(5, 10, Vector3.down);

            yield return new WaitForSeconds(0.5f);
        }

        Destroy(gameObject);

    }
}
