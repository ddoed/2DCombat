using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomUtility;
using UnityEngine.InputSystem;

public class InputUser : SingleTon<InputUser>
{
    Control control;

    [HideInInspector]public Vector2 moveInput;

    protected override void Awake()
    {
        control = new Control();
        control.Movement.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
    }

    private void Test(InputAction.CallbackContext context)
    {
        Debug.Log("test");
    }

    private void OnEnable()
    {
        control.Enable();
    }

    private void OnDisable()
    {
        control.Disable();
    }
}
