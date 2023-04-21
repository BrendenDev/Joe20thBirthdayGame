using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static InputAssignment;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    { 
        [Header("Velocity and X/Z Axis Movement")]
        [SerializeField] private InputActionReference wasdInput;
        [SerializeField] private float speed; 
        [SerializeField] private float velocityMax; 
        [Header("Jumping")]
        [SerializeField] private InputActionReference jumpButton; 
        [SerializeField] private float jumpStrength; 

        private bool isGrounded; 
        private Rigidbody body; 

        void Awake() 
        {
            body = this.GetComponent<Rigidbody>();
            EnableInput(new InputActionReference[] {jumpButton, wasdInput});
            jumpButton.action.performed += Jump;
        }

        void onEnable() 
        {
            EnableInput(new InputActionReference[] {jumpButton, wasdInput});
        }

        void onDisable() 
        {
            DisableInput(new InputActionReference[] {jumpButton, wasdInput});
        }
        
        void Update()
        {
            MoveXZ();
            CheckGrounded(); 
        }

        void FixedUpdate() 
        {
            TerminalVelocity();
        }

        private void MoveXZ() 
        {
            Vector2 moveInput = wasdInput.action.ReadValue<Vector2>();
            Vector3 moveDirection = transform.forward * moveInput.y + transform.right * moveInput.x;
            body.AddForce(moveDirection.normalized * speed, ForceMode.Force);
        }

        private void CheckGrounded() 
        {
            isGrounded = Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector3.down, 1.15f); //last number is height
        }

        private void Jump(InputAction.CallbackContext obj) 
        {
            if(isGrounded) 
            {
                body.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
            }
        }

        private void TerminalVelocity() 
        {
            //Enforce Terminal Velocity
            if(body.velocity.magnitude > velocityMax) 
            {
                body.velocity = Vector3.ClampMagnitude(body.velocity, velocityMax); 
            }
        }
    }
}
