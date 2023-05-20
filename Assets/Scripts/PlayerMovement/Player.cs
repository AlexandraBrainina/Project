using System;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
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

        private int _enemyDamage = 20;


        private void Start()
        {
            _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                TakeDamage(_enemyDamage);
            }
            else if (other.gameObject.CompareTag("Finish"))
            {
                LoadNextLevel();
            }
        }

        private void TakeDamage(int damage)
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

        private void LoadNextLevel()
        {
            SceneManager.LoadScene(_currentSceneIndex + 1);
        }
    }
}