using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBar : MonoBehaviour
{
    [SerializeField] GameObject[] heals;

    public void ShowHeal(int count)
    {
        for (int i = 0; i < heals.Length; i++)
        {
            if (i < count)
                heals[i].gameObject.SetActive(true);
            else
                heals[i].gameObject.SetActive(false);
        }
    }
}
