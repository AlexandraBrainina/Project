using System;
using UnityEngine;

namespace DefaultNamespace.Enemy
{
    public class EnemyBrain : MonoBehaviour
    {
        public Transform target;
        private EnemyReferences _enemyReferences;
        private float pathUpdateDeadline;
        private float _shootingDistance;

        private void Awake()
        {
            _enemyReferences = GetComponent<EnemyReferences>();
        }

        private void Start()
        {
            _shootingDistance = _enemyReferences.navMeshAgent.stoppingDistance;
        }

        private void Update()
        {
            if (target != null)
            {
                bool inRange = Vector3.Distance(transform.position, target.position) <= _shootingDistance;
                if (inRange)
                {
                    LookAtTarget();
                }
                else
                {
                    UpdatePath();
                }
                _enemyReferences.animator.SetBool("shooting", inRange);
            }
            _enemyReferences.animator.SetFloat("speed", _enemyReferences.navMeshAgent.desiredVelocity.sqrMagnitude);
        }
        
        private void LookAtTarget()
        {
            Vector3 lookPos = target.position - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
        }

        private void UpdatePath()
        {
            if (Time.time >= pathUpdateDeadline)
            {
                Debug.Log("Searching for player");
                pathUpdateDeadline = Time.time + _enemyReferences.pathUpdateDelay;
                _enemyReferences.navMeshAgent.SetDestination(target.position);
            }
        }

        
    }
}