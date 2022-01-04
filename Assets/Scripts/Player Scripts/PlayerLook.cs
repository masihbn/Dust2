using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Tags;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    private Transform playerRoot, lookRoot;

    [SerializeField]
    private bool invertLooks;

    [SerializeField]
    private float mouseSensivity = 5f;

    [SerializeField]
    private Vector2 lookLimits = new Vector2(-70f, 80f);

    private Vector2 lookAngles;

    private Vector2 currentMouseLook;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        LockAndUnlockCursor();
        
        if (Cursor.lockState == CursorLockMode.Locked)
            LookAround();
    }

    void LockAndUnlockCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
            {

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    private void LookAround()
    {
        currentMouseLook = new Vector2(Input.GetAxis(MouseAxis.MOUSE_Y), Input.GetAxis(MouseAxis.MOUSE_X));
        lookAngles.x += currentMouseLook.x * mouseSensivity * (invertLooks ? 1 : -1);
        lookAngles.y += currentMouseLook.y * mouseSensivity;

        // Limit look angles
        lookAngles.x = Mathf.Clamp(lookAngles.x, lookLimits.x, lookLimits.y);

        lookRoot.localRotation = Quaternion.Euler(lookAngles.x, 0f, 0f);
        playerRoot.localRotation = Quaternion.Euler(0f, lookAngles.y, 0f);
    }
}
