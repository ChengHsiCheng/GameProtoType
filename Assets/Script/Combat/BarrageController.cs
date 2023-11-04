using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BarrageMode
{
    ContinuousShoot, ScatterShoot
}

public class BarrageController : MonoBehaviour
{
    public ProjectileControls projectile;
    public BarrageMode barrageMode;
    public Vector3 InstantiatePos;
    public float speed;
    public float quantity;
    public float startAngleY;
    public float endAngleY;
    // public float angleInterval;
    public float shootInterval;

    private void Start()
    {
        if (barrageMode == BarrageMode.ScatterShoot)
        {
            for (int i = 0; i < quantity; i++)
            {
                float rotationAmount = ((endAngleY - startAngleY) / quantity) * i;
                Quaternion rotation = Quaternion.Euler(0, startAngleY + rotationAmount, 0);
                ProjectileControls _projectile = Instantiate(projectile, InstantiatePos, rotation);
                _projectile.SetValue(speed, _projectile.transform.forward);
            }
        }
        else if (barrageMode == BarrageMode.ContinuousShoot)
        {
            StartCoroutine(ContinuousShoot());
        }
    }

    private IEnumerator ContinuousShoot()
    {
        for (int i = 0; i < quantity; i++)
        {
            float rotationAmount = ((endAngleY - startAngleY) / quantity) * i;
            Quaternion rotation = Quaternion.Euler(0, startAngleY + rotationAmount, 0);
            ProjectileControls _projectile = Instantiate(projectile, InstantiatePos, rotation);
            _projectile.SetValue(speed, _projectile.transform.forward);

            yield return new WaitForSeconds(shootInterval);
        }
    }
}
