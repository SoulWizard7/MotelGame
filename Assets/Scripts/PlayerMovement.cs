using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CameraFollow cameraFollow;
    private Rigidbody2D rb;
    private Vector2 moveVector = Vector2.zero;
    private NormalControls input;
    [SerializeField] private float moveSpeed = 10f;

    void Awake(){
        cameraFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        cameraFollow.Player = this;
        input = new NormalControls();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
    }

    void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
            
    }

    void OnEnable(){
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCanceled;
    }

    void OnDisable(){
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCanceled;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value){
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCanceled(InputAction.CallbackContext value){
        moveVector = Vector2.zero;
    }   
}
