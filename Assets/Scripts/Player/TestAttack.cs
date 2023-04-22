using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static InputAssignment;
using NPC; 

namespace Player
{
    public class TestAttack : MonoBehaviour
    {
        [SerializeField] private InputActionReference basicAttack;
        [SerializeField] private float damage;
        private Transform playerCamera;

        void Awake() 
        {
            EnableInput(basicAttack);
            playerCamera = transform.GetChild(0);
            basicAttack.action.performed += Attack; 
        }

        void onEnable() 
        {
            EnableInput(basicAttack);
            basicAttack.action.performed += Attack; 
        }

        void onDisable() 
        {
            DisableInput(basicAttack);
            basicAttack.action.performed -= Attack; 
        }

        void Attack(InputAction.CallbackContext context) 
        {
            RaycastHit other;
            bool targetHit = Physics.Raycast(playerCamera.position, playerCamera.forward, out other, 5f);
            if(targetHit && other.collider.gameObject.tag == "NPC")
            {
                other.collider.gameObject.transform.GetChild(1).GetComponent<Animator>().SetBool("Active", !other.collider.gameObject.transform.GetChild(1).GetComponent<Animator>().GetBool("Active"));
                other.collider.gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Active", !other.collider.gameObject.transform.GetChild(1).GetComponent<Animator>().GetBool("Active"));
            }
            else if(targetHit && other.collider.gameObject.tag == "NPCPlus")
            {
                Application.OpenURL("https://grouptogether.page.link/jXVf");
            }
            else if(targetHit && other.collider.gameObject.tag == "NPCQuit")
            {
                Application.Quit();
            }
        }

        void Update() {
            Debug.DrawRay(playerCamera.position, playerCamera.forward * 5f, Color.green);
        }
    }
}
