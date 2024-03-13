using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintUI : MonoBehaviour
{
    public GameObject target;

    private void Update()
    {
        if (!target) return;

        transform.position = Camera.main.WorldToScreenPoint(target.transform.parent.position);
    }
}
