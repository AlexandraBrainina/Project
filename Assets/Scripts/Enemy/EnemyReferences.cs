using System;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace.Enemy
{
    [DisallowMultipleComponent]
    public class EnemyReferences : MonoBehaviour
    {
        [HideInInspector]public NavMeshAgent navMeshAgent;
        [HideInInspector]public Animator animator;

        public float pathUpdateDelay = 0.2f;
        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
        }
    }
}