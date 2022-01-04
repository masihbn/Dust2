using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Tags;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    Vector3 moveDirection;
    public float speed = 5f, jumpForce = 10f;
    private float verticalSpeed, gravity =  20f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        moveDirection = new Vector3(Input.GetAxis(Axis.Horizontal), 0f, Input.GetAxis(Axis.Vertical));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;

        ApplyGravity();
     
        characterController.Move(moveDirection);
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
