using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueSkillTrigger : MonoBehaviour
{
    public event Action<Collider> TriggerEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            TriggerEvent?.Invoke(other);
    }
}

