using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NPC
{
    public class NPCHealthBar : MonoBehaviour
    {
        private Transform playerPosition;  
        private Quaternion initialRotation; 
        private Animator textAnimator; 
        private Animator imageAnimator;

        void Start()
        {
            playerPosition = GameObject.FindWithTag("Player").transform.GetChild(1).transform;
            textAnimator = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
            imageAnimator = this.gameObject.transform.GetChild(1).GetComponent<Animator>();
        }

        void Awake()
        {
            initialRotation = Quaternion.Euler(0, this.transform.localEulerAngles.y, 0);
        }

        void Update()
        {
            if((playerPosition.position - transform.position).magnitude < 6 && textAnimator.GetBool("Active") == false) 
            {
                Vector3 lookPosition = playerPosition.position - transform.position; 
                lookPosition.y = 0;
                transform.rotation = Quaternion.RotateTowards(Quaternion.LookRotation(transform.forward), Quaternion.LookRotation(-lookPosition.normalized), 100f * Time.deltaTime);
            }
            else if((playerPosition.position - transform.position).magnitude > 6)
            {
                transform.rotation = Quaternion.RotateTowards(Quaternion.LookRotation(transform.forward), initialRotation, 100f * Time.deltaTime);
                textAnimator.SetBool("Active", false);
                imageAnimator.SetBool("Active", true);
            }
            else if(transform.rotation.y != initialRotation.y && textAnimator.GetBool("Active") == false)
            {
                transform.rotation = Quaternion.RotateTowards(Quaternion.LookRotation(transform.forward), initialRotation, 100f * Time.deltaTime);
            }
        }   

    }
}
