using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface San
{
    float maxSan { get; }
    float san { get; }
    event Action OnUpdateSan;

    void DealSanDamage(float damage);
}
