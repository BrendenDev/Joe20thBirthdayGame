using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NPC
{
    public class NPCHealthBar : MonoBehaviour
    {
        private float health; 
        private GameObject healthBar; //maybe make the health bar scale based on health
        private Slider bar;
        private Transform playerPosition;  

        void Start()
        {
            playerPosition = GameObject.FindWithTag("Player").transform;
            healthBar = transform.GetChild(0).gameObject;
            bar = transform.GetChild(0).GetChild(0).gameObject.GetComponent<Slider>(); 
            bar.maxValue = gameObject.GetComponent<NonPlayerCharacter>().MaxHealth;
        }

        void Update()
        {
            Vector3 lookPosition = playerPosition.position - transform.position; 
            lookPosition.y = 0; 
            transform.rotation = Quaternion.LookRotation(lookPosition.normalized);
            //healthBar.transform.LookAt(playerPosition);
            health = gameObject.GetComponent<NonPlayerCharacter>().Health;
            bar.value = health;
        }

    }
}
