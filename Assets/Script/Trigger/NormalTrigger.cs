using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTrigger : Trigger
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsInRadius = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsInRadius = false;
        }
    }
}
