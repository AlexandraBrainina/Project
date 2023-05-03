using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float bulletSpeed;
        private float _shootDelay = .2f;
        private bool _canShoot = true;
        
        private void Update()
        {
            if (Input.GetMouseButton(0) && _canShoot)
            {
                var bullet = Instantiate(this.bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
                _canShoot = false;
                StartCoroutine(WaitForDelay());
            }
        }

        IEnumerator WaitForDelay()
        {
            yield return new WaitForSeconds(_shootDelay);
            _canShoot = true;
        }

        
    }
}