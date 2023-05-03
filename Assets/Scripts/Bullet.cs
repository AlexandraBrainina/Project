using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bullet : MonoBehaviour
    {
        private float lifeTime = 3f;

        private void Awake()
        {
            Destroy(gameObject, lifeTime);            
        }

        private void OnCollisionEnter(Collision collision)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}