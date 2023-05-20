using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


namespace DefaultNamespace
{
    public class Enemy : MonoBehaviour
    {
        public EnemyData enemyData;
        
        private int _health = 1;

        private void Start()
        {
            _health = enemyData.enemyHealth;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Damager"))
            {
                TakeDamage(1);
            }
        }

        private void TakeDamage(int damage)
        {
            _health -= damage;
        }

        private void Update()
        {
            if (_health <= 0)
            {
                //playAnimation
                Destroy(gameObject);
            }
        }
    }
}