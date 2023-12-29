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

    // variables to store player input values
    private Vector2 currentMovementInput;
    private Vector3 currentMovement;
    private bool isMovementPressed;


    [SerializeField] private float speed;


    private void Awake()
    {
        _playerInput = new PlayerInput();
        _characterController = GetComponent<CharacterController>();

        _playerInput.CharacterControls.Move.started += onMovementInput;
        _playerInput.CharacterControls.Move.canceled += onMovementInput;
        _playerInput.CharacterControls.Move.performed += onMovementInput;
        
    }

    void onMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;

        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    // Update is called once per frame
    void Update()
    {
        _characterController.Move(currentMovement * (speed * Time.deltaTime));
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
