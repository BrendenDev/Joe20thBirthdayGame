using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC {
    public class NonPlayerCharacter : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        public float MaxHealth 
        {
            get => maxHealth; 
            set => value = maxHealth; 
        }
        [SerializeField] private float health;
        public float Health
        {
            get => health; 
            set => value = health; 
        }

        public void DamageTaken(float damage) 
        {
            health -= damage;
            if (health == 0) {
                Destroy(gameObject);
            }
        }
    }
}

