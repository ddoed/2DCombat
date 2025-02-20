using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Storage storage;
    UISlot slot;
    GameObject dragInstance;

    bool canDrag;

    public void SetupStorage(Storage storage, UISlot slot)
    {
        this.storage = storage;
        this.slot = slot;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!canDrag) return;

        storage.SwapItem(slot); // storage UIslot 后 按眉俊 单捞磐 持绢林扁

        dragInstance = new GameObject($"Drag{slot.name}");
        var image = dragInstance.AddComponent<Image>();
        image.sprite = slot.itemImage.sprite;
        image.raycastTarget = false;

        dragInstance.transform.SetParent(storage.transform);
        dragInstance.transform.localScale = Vector3.one;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(dragInstance != null)
        {
            dragInstance.transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject is GameObject target)
        {
            var targetSlot = target.GetComponentInParent<UISlot>();
            if (targetSlot != null)
            {
                storage.SwapItem(targetSlot);
                EventSystem.current.SetSelectedGameObject(target);
            }
        }
        storage.ClearSwap();
        if(dragInstance != null)
        {
            Destroy(dragInstance);
        }
    }

    public void SetDragAbility(bool ability)
    {
        canDrag = ability;
    }
}
