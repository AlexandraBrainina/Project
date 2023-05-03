using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;

    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.81f;

    public float jump = 1f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector2 _look;
    [SerializeField] private float mouseSensetivity = 3f;
    [SerializeField] private Transform cameraTransform;

    public Vector3 velocity;
    bool isGrounded;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        UpdateGravity();
        UpdateMovement();
        UpdateLook();
       // UpdateSliding();
    }


    private void UpdateGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }


    private void UpdateMovement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * (speed * Time.deltaTime));


        //jump____________________
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //dash____________________
    }

    private void UpdateLook()
    {
        _look.x += Input.GetAxis("Mouse X") * mouseSensetivity;
        _look.y += Input.GetAxis("Mouse Y") * mouseSensetivity;

        _look.y = Mathf.Clamp(_look.y, -89.9f, 89.9f);

        transform.localRotation = Quaternion.Euler(0, _look.x, 0);
        cameraTransform.localRotation = Quaternion.Euler(-_look.y, 0, 0);
    }


    private void UpdateSliding()
    {
        
    }
}