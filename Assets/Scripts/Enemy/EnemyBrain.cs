using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class EnemyBrain : MonoBehaviour
    {
        public Transform target;
        private EnemyReferences _enemyReferences;
        private float _attackDistance;
        private float _pathUpdateDeadline;

        private void Awake()
        {
            _enemyReferences = GetComponent<EnemyReferences>();
        }

        private void Start()
        {
            _attackDistance = _enemyReferences.navMeshAgent.stoppingDistance;
        }

        private void Update()
        {
            if (target != null)
            {
                bool inRange = Vector3.Distance(transform.position, target.position) <= _attackDistance;
                
                if (inRange)
                {
                    LookAtTarget();
                }
                else
                {
                    UpdatePath();
                }
                _enemyReferences.animator.SetBool("attacking", inRange);
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
            if (Time.time >= _pathUpdateDeadline)
            {
                _pathUpdateDeadline = Time.time + _enemyReferences.pathUpdateDelay;
                _enemyReferences.navMeshAgent.SetDestination(target.position);
            }
        }
    }
}