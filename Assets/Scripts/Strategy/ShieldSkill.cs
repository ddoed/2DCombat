using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Shield", menuName ="Skill/Shield")]
public class ShieldSkill : BaseStrategy
{
    public GameObject shieldPrefab;
    public float duration = 5f;

    public override void CastSpell(Transform origin)
    {
        var shield = Instantiate(shieldPrefab, origin.transform.position, Quaternion.identity);
        shield.transform.SetParent(origin);
        Destroy(shield, duration);
    }
}
