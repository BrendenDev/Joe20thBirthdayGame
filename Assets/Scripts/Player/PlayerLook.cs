using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

namespace Player 
{
    public class PlayerLook : MonoBehaviour
    {
        [Header("Mouse Sensitivity")]
        [SerializeField] private float sens; 
        [SerializeField] private InputActionReference lookRef; 

        [SerializeField] private Transform pitchCam; //camera
        [SerializeField] private Transform yawCam; //body 
        private Vector2 rotation; 

        public float conversion;

        void Start()
        {
            this.transform.localRotation = transform.parent.rotation; 
            lookRef.action.Enable();
            Cursor.lockState = CursorLockMode.Locked; 
            Cursor.visible = false;
        }

        private void onEnable()
        {
            lookRef.action.Enable();
            Cursor.lockState = CursorLockMode.Locked; 
            Cursor.visible = false;
        }
        
        private void onDisable() 
        {
            lookRef.action.Disable();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        void Update()
        {
            rotation += lookRef.action.ReadValue<Vector2>() * sens * conversion;
            
            float epsilon = 0.01f;
            rotation.x %= 360f;
            rotation.y = Mathf.Clamp(rotation.y, -90f + epsilon, 90f - epsilon);

            pitchCam.localRotation = Quaternion.Euler(-rotation.y, pitchCam.localEulerAngles.y, pitchCam.localEulerAngles.z);
            yawCam.localRotation = Quaternion.Euler(yawCam.localEulerAngles.x, rotation.x, yawCam.localEulerAngles.z);
        }
    }
}
