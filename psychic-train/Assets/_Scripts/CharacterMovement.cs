using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    //declare reference variables
    private PlayerInput _playerInput;
    private CharacterController _characterController;
    
    //Animation components
    private Animator _animator;

    // variables to store player input values
    private Vector2 currentMovementInput;
    private Vector3 currentMovement;
    private bool isMovementPressed;
    
    
    [SerializeField] private float rotationSpeed = 360;
    
    [SerializeField] private float speed;

    

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _characterController = GetComponent<CharacterController>();

        _playerInput.CharacterControls.Move.started += onMovementInput;
        _playerInput.CharacterControls.Move.canceled += onMovementInput;
        _playerInput.CharacterControls.Move.performed += onMovementInput;

        _animator = GetComponent<Animator>();

    }

    void onMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;

        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;

        if (isMovementPressed)
        {
            _animator.SetBool("isWalking", true);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentMovement), 0.15f);
        }

        if (!isMovementPressed)
        {
            _animator.SetBool("isWalking", false);
        }
    }
    


    // Update is called once per frame
    void Update()
    {
        _characterController.Move(currentMovement * (speed * Time.deltaTime));
        if (isMovementPressed)
        {
            // Calculate the desired rotation based on the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(currentMovement);

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        
    }

    private void OnEnable()
    { 
        _playerInput.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        _playerInput.CharacterControls.Disable();
    }
    
    
    
}
