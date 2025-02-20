using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISkilltreeStorage : Storage
{
    public override void SetSlot()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            UISkillSlot slot = slots[i] as UISkillSlot;
            slot.UpdateUI(items[i]);
            slot.SetupStorage(this);
            slot.SetupMouseDrag(this);

            if (!slot.Unlocked)
                slot.LockMouseDrag();
        }
    }

    public override void Start()
    {
        base.Start();

        foreach(var slot in slots)
        {
            UISkillSlot skillSlot = slot as UISkillSlot;
            skillSlot.OnSkillUnlock += SetSlot;
        }
    }
}
