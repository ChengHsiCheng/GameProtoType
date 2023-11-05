using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss03Crystal : MonoBehaviour
{
    public event Action<Boss03Crystal> OnDestroyEvent;

    [field: SerializeField] public EnemyInfo Info { get; private set; }

    private void Start()
    {
        Info.OnDie += Die;
    }

    private void OnDisable()
    {
        Info.OnDie -= Die;
    }

    private void Die()
    {
        OnDestroyEvent?.Invoke(this);
        Destroy(gameObject);
    }

}
