using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Tags;

public class PlayerMovement : MonoBehaviour
{
    private Transform look_Root;
    CharacterController characterController;
    Vector3 moveDirection;

    public float speed, normalSpeed = 5f, sprintSpeed = 10f, crouchSpeed = 2f
        , jumpForce = 10f;
    private float verticalSpeed, gravity = 20f;

    private float stand_Height = 0f;
    private float crouch_Height = -0.6f;

    private bool isCrouching;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        look_Root = transform.GetChild(0);
        speed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        Sprint();
        Crouch();

        moveDirection = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;

        ApplyGravity();

        characterController.Move(moveDirection);
    }

    private void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isCrouching = false;
            look_Root.localPosition = new Vector3(0f, stand_Height, 0f);
            speed = sprintSpeed;
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
            speed = normalSpeed;
    }


    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isCrouching)
            {
                look_Root.localPosition = new Vector3(0f, stand_Height, 0f);
                speed = normalSpeed;

                isCrouching = false;
            }
            else
            {
                look_Root.localPosition = new Vector3(0f, crouch_Height, 0f);
                speed = crouchSpeed;

                isCrouching = true;
            }
        }
    }

    private void ApplyGravity()
    {
        verticalSpeed -= gravity * Time.deltaTime;
        PlayerJump();

        moveDirection.y = verticalSpeed * Time.deltaTime;
    }

    private void PlayerJump()
    {
        if (characterController.isGrounded &&
            Input.GetKeyDown(KeyCode.Space))
            verticalSpeed = jumpForce;
    }
}
