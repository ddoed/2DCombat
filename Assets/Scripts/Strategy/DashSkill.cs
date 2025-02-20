using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dash", menuName ="Skill/Dash")]
public class DashSkill : BaseStrategy
{
    public static Action OnSkillUsed;

    public override void CastSpell(Transform origin)
    {
        Debug.Log("Dash");
        OnSkillUsed?.Invoke();
    }
}
