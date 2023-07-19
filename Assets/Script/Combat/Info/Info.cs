using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Info
{
    event Action OnDie;
    bool isInvulnerable { get; set; }
    bool isDead { get; }
    void SetInvulnerable(bool isInvunerable);
}
