using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class PowerUp : MonoBehaviour
    {
        private void Update()
        {
            transform.localRotation = Quaternion.Euler(0, Time.time * 100f, 0);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Use(other);
            }
        }

        private void Use(Collider player)
        {
            Player stats = player.GetComponent<Player>();
            stats.currentHealth += 20;
            Destroy(gameObject);
        }
    }
}