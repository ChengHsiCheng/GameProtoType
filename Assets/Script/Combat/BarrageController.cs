using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BarrageMode
{
    ContinuousShoot, ScatterShoot
}

public class BarrageController : MonoBehaviour
{
    [SerializeField] private ProjectileControls projectile;
    [SerializeField] private BarrageMode barrageMode;
    private Vector3 InstantiatePos;
    [SerializeField] private float speed;
    [SerializeField] private int quantity;
    [SerializeField] private float startAngleY;
    [SerializeField] private float endAngleY;
    [SerializeField] private float shootInterval;

    [SerializeField] private bool back;

    private int count;

    private void Start()
    {
        Shoot();
    }

    public void Shoot()
    {
        Debug.Log("Shoot");
        count = 0;

        if (barrageMode == BarrageMode.ScatterShoot)
        {
            for (int i = 0; i < quantity; i++)
            {
                ShootProjectile();
            }
        }
        else if (barrageMode == BarrageMode.ContinuousShoot)
        {
            InvokeRepeating("ShootProjectile", 0, 0.1f);
        }

    }

    private void ShootProjectile()
    {
        float rotationAmount = 0;
        if (!back)
        {
            rotationAmount = ((endAngleY - startAngleY) / quantity) * count + transform.eulerAngles.y;
        }
        else
        {
            rotationAmount = ((startAngleY - endAngleY) / quantity) * count + transform.eulerAngles.y + 180;
        }

        Quaternion rotation = Quaternion.Euler(0, startAngleY + rotationAmount, 0);
        ProjectileControls _projectile = Instantiate(projectile, InstantiatePos, rotation);
        _projectile.SetValue(speed, _projectile.transform.forward);
        count++;

        if (count >= quantity)
        {
            CancelInvoke("ShootProjectile");
        }
    }

    private IEnumerator ContinuousShoot()
    {
        yield return null;
    }


    public void SetInstantiatePos(Transform InstantiateTra)
    {
        InstantiatePos = InstantiateTra.position;
        InstantiatePos.y = 1;
    }

    public void SetProjectile(ProjectileControls projectile, BarrageMode barrageMode, Transform InstantiateTra)
    {
        this.projectile = projectile;
        this.barrageMode = barrageMode;
        SetInstantiatePos(InstantiateTra);
    }

    public void SetValue(float speed, int quantity, float startAngleY, float endAngleY, float shootInterval)
    {
        this.speed = speed;
        this.quantity = quantity;
        this.startAngleY = startAngleY;
        this.endAngleY = endAngleY;
        this.shootInterval = shootInterval;
    }
}
