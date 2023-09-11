using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public Camera playerCamera;

    [SerializeField] private float walkSpeed = 7f;
    [SerializeField] private float gravity = 20f;
    [SerializeField] private float lookSpeed = 2f;
    [SerializeField] private float lookXLimit = 75f;
    [SerializeField] private bool canMove = true;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;

    void Start()
    {
        // controller setup
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // handle moving
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float currentSpeedX = canMove ? walkSpeed * Input.GetAxis("Vertical") : 0;
        float currentSpeedY = canMove ? walkSpeed * Input.GetAxis("Horizontal") : 0;
        float currentDirectionY = moveDirection.y;

        // handle direction
        moveDirection = (forward * currentSpeedX) + (right * currentSpeedY);

        // handle gravity
        if (!characterController.isGrounded)
        {
            moveDirection.y = currentDirectionY;
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // handle camera
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        // apply direction
        characterController.Move(moveDirection * Time.deltaTime);
    }

    public void Enable()
    {
        canMove = true;
    }

    public void Disable()
    {
        canMove = false;
    }
}
