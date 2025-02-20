using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [Tooltip("swap 기능에 대한 토글")]
    [SerializeField] bool staticStorage;

    [SerializeField] protected List<UISlot> slots = new List<UISlot>();
    [SerializeField] protected List<Item> items = new List<Item>();

    UISlot swapUISlot;

    public virtual void Start()
    {
        SetSlot();
    }

    private void SetSlot()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].UpdateUI(items[i]);
            slots[i].SetupStorage(this);
            slots[i].SetupMouseDrag(this);
        }
    }

    public void SwapItem(UISlot otherSlot)
    {
        if (swapUISlot == null)
        {
            swapUISlot = otherSlot;
        }
        else if (swapUISlot == otherSlot) // 캔슬
        {
            ClearSwap();
        }
        else // 실제 swap 로직
        {
            Storage storage1 = swapUISlot.GetStorage();
            int index1 = GetItemIndex(swapUISlot);
            Item item1 = GetItem(index1);

            Storage storage2 = otherSlot.GetStorage();
            int index2 = GetItemIndex(swapUISlot);
            Item item2 = GetItem(index2);

            if (!staticStorage)
            {
                storage1.SetItemSlot(index1, item2);
                swapUISlot.UpdateUI(item2);
            }
            if (!staticStorage)
            {
                storage1.SetItemSlot(index2, item1);
                otherSlot.UpdateUI(item1);
            }

            swapUISlot = null;
        }
    }

    public void ClearSwap()
    {
        swapUISlot = null;
    }

    int GetItemIndex(UISlot slot) => slots.IndexOf(slot);
    public Item GetItem(int index) => items[index];
    void SetItemSlot(int index, Item item) => items[index] = item;
}
