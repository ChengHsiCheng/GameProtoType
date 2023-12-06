using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss03Idle : MonoBehaviour
{
    [SerializeField] private GameObject BigRing;
    [SerializeField] private GameObject SmallRing;

    [SerializeField] private float baseRingSpeed;
    void Start()
    {

    }

    void Update()
    {
        Whirling(Vector3.one, 1, Time.deltaTime);
    }

    protected void Whirling(Vector3 euluers, float speedAdd, float deltaTime)
    {
        BigRing.transform.Rotate(euluers.normalized * baseRingSpeed * speedAdd * deltaTime);
        SmallRing.transform.Rotate(-euluers.normalized * baseRingSpeed * speedAdd * deltaTime);
    }
}
