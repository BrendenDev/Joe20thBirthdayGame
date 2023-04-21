using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static InputAssignment;
using NPC; 

namespace Player
{
    public class TestAbility : MonoBehaviour
    {
        [SerializeField] private InputActionReference abilityButton;
        [SerializeField] private float damage;
        [SerializeField] private GameObject electricity;
        private Transform playerCamera;

        void Awake() 
        {
            EnableInput(abilityButton);
            playerCamera = transform.GetChild(0);
            abilityButton.action.started += Attack; 
            //abilityButton.action.canceled += CancelAttack; 
        }

        void onEnable() 
        {
            EnableInput(abilityButton);
            abilityButton.action.started += Attack; 
            abilityButton.action.canceled += CancelAttack; 
        }

        void onDisable() 
        {
            DisableInput(abilityButton);
            abilityButton.action.started -= Attack; 
            abilityButton.action.canceled -= CancelAttack; 
        }

        void Attack(InputAction.CallbackContext context) 
        {
            GameObject temp = Instantiate(electricity); 
            
            temp.transform.parent = playerCamera;
            temp.transform.localPosition = new Vector3(0, 0,0);
            temp.transform.localRotation = playerCamera.localRotation;
            
            //temp.transform.rotation = Quaternion.identity;
            
        }

        void CancelAttack(InputAction.CallbackContext context) 
        {
            Destroy(transform.GetChild(0).GetChild(0).gameObject);
        }

        void Update() {
            Debug.DrawRay(playerCamera.position, playerCamera.forward * 5f, Color.green);
        }
    }
}
