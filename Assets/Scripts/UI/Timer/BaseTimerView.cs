using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTimerView : TimerView
{
    public override void Awake()
    {
        base.Awake();
        duration = baseAttack.AttackCD;
    }
}
