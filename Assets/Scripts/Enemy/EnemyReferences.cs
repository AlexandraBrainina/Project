using System;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    public class EnemyReferences : MonoBehaviour
    {
        public NavMeshAgent navMeshAgent;
        public Animator animator;

        public float pathUpdateDelay = .2f;
        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
        }
    }
}