using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PickUpController : MonoBehaviour
    {
        public Weapon weaponScript;
        public Transform player, holdPos, cam;

        [SerializeField] private float pickUpRange = 4f;
        public bool equipped;

        private void Start()
        {
            weaponScript.enabled = false;
        }

        void Update()
        {
            Vector3 distanceToPlayer = player.position - transform.position;
            if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E))
            {
                PickUp();
            }
        }

        private void PickUp()
        {
            equipped = true;
            weaponScript.enabled = true;
            transform.SetParent(holdPos);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.localScale = Vector3.one;
        }
    }
}