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
    [SerializeField] private Vector3 InstantiatePos;
    [SerializeField] private float speed;
    [SerializeField] private int quantity;
    [SerializeField] private float startAngleY;
    [SerializeField] private float endAngleY;
    [SerializeField] private float shootInterval;
    [SerializeField] private bool back;

    private int count;
    private int angleCount;

    private void Start()
    {
        Shoot();
    }

    public void Shoot()
    {
        Debug.Log("Shoot");
        count = 0;

        if (back)
        {
            angleCount = quantity;
        }
        else
        {
            angleCount = 0;
        }

        if (barrageMode == BarrageMode.ScatterShoot)
        {
            for (int i = 0; i < quantity; i++)
            {
                ShootProjectile();
            }
        }
        else if (barrageMode == BarrageMode.ContinuousShoot)
        {
            Debug.Log("ShootProjectile");
            InvokeRepeating("ShootProjectile", 0, shootInterval);
        }

    }

    private void ShootProjectile()
    {
        float rotationAmount;

        if (back)
        {
            angleCount--;
        }
        else
        {
            angleCount++;
        }

        rotationAmount = ((endAngleY - startAngleY) / quantity) * angleCount + transform.eulerAngles.y;

        Quaternion rotation = Quaternion.Euler(0, startAngleY + rotationAmount, 0);
        ProjectileControls _projectile = Instantiate(projectile, InstantiatePos, rotation);
        _projectile.SetValue(speed, _projectile.transform.forward);
        count++;

        if (count >= quantity)
        {
            CancelInvoke("ShootProjectile");
        }
    }


    public void SetInstantiatePos(Transform InstantiateTra)
    {
        InstantiatePos = InstantiateTra.position;
        InstantiatePos.y = 1;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, InstantiateTra.eulerAngles.y, transform.eulerAngles.z);
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
