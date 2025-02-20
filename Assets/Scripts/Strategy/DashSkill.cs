using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dash", menuName ="Skill/Dash")]
public class DashSkill : BaseStrategy
{
    public static Action<float, float> OnSkillUsed;

    public float DashPower = 20f;
    public float DashTime = 0.25f;

    public override void CastSpell(Transform origin)
    {
        OnSkillUsed?.Invoke(DashPower, DashTime);
    }
}
