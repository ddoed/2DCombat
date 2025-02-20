using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public Image itemImage;
    Storage storage;
    MouseDrag mouseDrag;

    public void SetupStorage(Storage storage)
    {
        this.storage = storage;
    }

    public Storage GetStorage()
    {
        return storage;
    }

    public void UpdateUI(Item item)
    {
        if (item == null)
        {
            itemImage.sprite = null;
        }
       itemImage.sprite = item.IconImage;
    }

    public void SetupMouseDrag(Storage storage)
    {
        if (mouseDrag == null)
        {
            mouseDrag = gameObject.AddComponent<MouseDrag>();
        }
        else
        {
            mouseDrag = gameObject.GetComponent<MouseDrag>();
        }
        mouseDrag.SetDragAbility(true);
        mouseDrag.SetupStorage(storage, this);
    }

    public void LockMouseDrag()
    {
        mouseDrag.SetDragAbility(false);
    }
}
