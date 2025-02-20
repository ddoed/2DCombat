using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStrategy : ScriptableObject
{
    public abstract void CastSpell(Transform origin);
}
