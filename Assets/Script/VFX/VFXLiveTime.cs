using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXLiveTime : MonoBehaviour
{
    [SerializeField] private float liveTime;

    private void Start()
    {
        Destroy(gameObject, liveTime);
    }
}
