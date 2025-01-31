using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOptionView : MonoBehaviour
{
    public void SwitchTo(GameObject _menu)
    {
        SwitchOff();
        _menu?.SetActive(true);
    }

    public void SwitchOff()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
