using System;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Player : MonoBehaviour
    {
        //SCENE
        private int _currentSceneIndex;

        //HEALTH
        public int maxHealth = 100;
        public int currentHealth;
        public HealthBar healthBar;

        private void Start()
        {
            _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Damager"))
            {
                TakeDamage(20);
            }
            else if (other.gameObject.CompareTag("Finish"))
            {
                LoadNextLevel();
            }
        }


        private void LoadNextLevel()
        {
            SceneManager.LoadScene(_currentSceneIndex + 1);
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }

        private void Update()
        {
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene(_currentSceneIndex);
            }

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
}