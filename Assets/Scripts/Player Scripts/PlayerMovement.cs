using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Tags;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    Vector3 moveDirection;
    public float speed = 5f, gravity =  20f, jumpForce = 10f, verticalSpeed;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMove();
    }

    void playerMove()
    {
        moveDirection = new Vector3(Input.GetAxis(Axis.Horizontal), 0f, Input.GetAxis(Axis.Vertical));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;
     
        characterController.Move(moveDirection);
    }
}
