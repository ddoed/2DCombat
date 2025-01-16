using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7.5f;
    [SerializeField] private float jumpPower = 7f;
    [SerializeField] private float jumpTime = 0.5f;
    [SerializeField] private float extraHeight = 0.25f;
    [SerializeField] private LayerMask whatIsGround;

    Rigidbody2D rigid;
    Animator anim;
    Collider2D coll;

    private bool isFacingRight = false;
    private bool isJumping;
    private bool isFalling;
    private RaycastHit2D groundHit;
    private float jumpTimeCounter;

    private Coroutine resetTrigger;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }
    private void Update()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        // 플레이어의 소점프
        if (InputUser.Instance.control.Jumping.Jump.WasPerformedThisFrame() && IsGrounded())
        {
            isJumping = true;
            jumpTimeCounter = Time.time;
            rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
        }
        // 플레이어의 대점프
        if (InputUser.Instance.control.Jumping.Jump.WasPressedThisFrame())
        {
            if (jumpTimeCounter > 0)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
                jumpTimeCounter -= Time.deltaTime;
            }
            else if (jumpTimeCounter == 0) // 점프 끝
            {

            }
            else // 땅에 착륙
            {
                isJumping = false;
            }
        }

        if (InputUser.Instance.control.Jumping.Jump.WasReleasedThisFrame())
        {

        }

        DrawGroundCheck();
    }

    private bool CheckForLand()
    {
        if(isFalling)
        {
            if(IsGrounded())
            {
                isFalling = false;
                return true;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }

    private bool IsGrounded()
    {
        groundHit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down,
            extraHeight, whatIsGround);
        if(groundHit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    #region Debug Function

    private void DrawGroundCheck()
    {
        Color rayColor;

        if (IsGrounded())
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(coll.bounds.center + 
            new Vector3(coll.bounds.extents.x, 0),
            Vector2.down * (coll.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(coll.bounds.center -
            new Vector3(coll.bounds.extents.x, 0),
            Vector2.down * (coll.bounds.extents.y + extraHeight), rayColor);
    }
    #endregion

    private void Move()
    {
        float horizontal = InputUser.Instance.moveInput.x;

        if(Math.Abs(horizontal) > 0) // 입력값이 있을 때
        {
            anim.SetBool("isWalking", true);
            TurnCheck();
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        rigid.velocity = new Vector2(horizontal * moveSpeed, rigid.velocity.y);
    }

    #region
    private void TurnCheck()
    {
        if (InputUser.Instance.moveInput.x > 0 && !isFacingRight)
        {
            Turn();
        }
        else if (InputUser.Instance.moveInput.x < 0 && isFacingRight)
        {
            Turn();
        }
    }

    private void Turn()
    {
        if(isFacingRight)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = !isFacingRight;
        }
        else
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = !isFacingRight;
        }
    }
    #endregion
}
