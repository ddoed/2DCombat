using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomUtility;
using UnityEngine.InputSystem;

public class InputUser : SingleTon<InputUser>
{
    [HideInInspector] public Control control;

    [HideInInspector] public Vector2 moveInput;

    public bool MenuIsOpen { get; set; } = false;

    public Action MenuOpen;
    public Action MenuClose;
    public Action BaseAttack;

    protected override void Awake()
    {
        control = new Control();
        control.Movement.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        control.UI.MenuOpen.performed += UIMenuPerformed;
        control.Attack.MeleeAttack.performed += PlayerBaseAttack;
    }

    private void PlayerBaseAttack(InputAction.CallbackContext context)
    {
        BaseAttack?.Invoke();
    }

    private void UIMenuPerformed(InputAction.CallbackContext context)
    {
        MenuIsOpen = !MenuIsOpen;

        if (MenuIsOpen)
        {
            MenuOpen?.Invoke();
        }
        else
        {
            MenuClose?.Invoke();
        }
    }

    #region Unity Function
    private void OnEnable()
    {
        control.Enable();
    }

    private void OnDisable()
    {
        control.Disable();
    }
    #endregion
}
