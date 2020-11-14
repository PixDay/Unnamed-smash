﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float rotSpeed = 20.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 Direction = Vector3.zero;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            moveDirection *= speed;
            
            if (moveDirection != Vector3.zero)
                Direction = moveDirection;
            transform.rotation = Quaternion.LookRotation(Direction * Time.deltaTime);
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }         
        }
        moveDirection.y -= gravity * Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
