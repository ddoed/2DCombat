using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkillSlot : UISlot
{
    public Action OnSkillUnlock;

    private bool unlocked;
    public bool Unlocked => unlocked;

    [SerializeField] private UISkillSlot[] shouldBeUnlocked;
    [SerializeField] private UISkillSlot[] shoudBeLocked;

    [SerializeField] private Item item;
    private Button _button;

    private void Start()
    {
        itemImage = GetComponent<Image>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(UnlockSkillSlot);

        if(!unlocked)
            itemImage.color = Color.red;
    }

    private void OnValidate()
    {
        gameObject.name = $"SkillTreeSlot_UI - {item.itemName}";
    }

    private void UnlockSkillSlot()
    {
        if (unlocked) return;
        // shouldBeUnlocked가 하나라도 lock이면 return
        for (int i = 0; i < shouldBeUnlocked.Length; i++)
        {
            if(shouldBeUnlocked[i].Unlocked == false)
            {
                return;
            }

        }

        // shouldBelocked가 하나라도 unlock이면 return
        for (int i = 0; i < shoudBeLocked.Length; i++)
        {
            if (shoudBeLocked[i].Unlocked == true)
            {
                return;
            }
        }

        unlocked = true;
        itemImage.color = Color.white;

        OnSkillUnlock?.Invoke();
    }
}
