using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOptionView : MonoBehaviour
{
    public GameObject defaultObject;
    private void Awake()
    {
        InputUser.Instance.MenuOpen += PauseOn;
        InputUser.Instance.MenuClose += PauseOff;
        SwitchOff();
    }

    private void PauseOn()
    {
        Time.timeScale = 0;
        SwitchTo(defaultObject);
    }

    private void PauseOff()
    {
        Time.timeScale = 1;
        SwitchOff();
    }

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
