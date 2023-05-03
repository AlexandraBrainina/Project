using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Sunflower : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 60f;
        public float currentHealth;
        public HealthBar healthBar;

        private void Start()
        {
            currentHealth = maxHealth;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Damager"))
            {
                TakeDamage(20);
            }
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthBar.SetMaxHealth(currentHealth);
        }
    }
}
