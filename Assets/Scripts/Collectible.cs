using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Collectible : MonoBehaviour
    {
        public static event Action OnCollected;
        public static int total;
        void Awake() => total++;
        private void Update()
        {
            transform.localRotation = Quaternion.Euler(0, Time.time * 100f, 0);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnCollected?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}