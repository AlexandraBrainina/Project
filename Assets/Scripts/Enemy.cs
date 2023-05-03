using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Enemy : MonoBehaviour
    { 
        //GENERAL
        private NavMeshAgent agent;
        private Transform player;
        private LayerMask whatIsGround, whatIsPlayer;
        private float agentHealth = 100f;
        
        //PATROLLING
        public Vector3 walkPoint;
        private bool walkPointSet;
        public float walkPointRange;

        //ATTACKING
        private float timeBetweenAttacks;
        private bool alreadyAttacked;

        //STATES
        private float sightRange, attackRange;
        private bool palyerInSightRange, playerInAttackRange;

        private void Awake()
        {
            player = GameObject.Find("Player").transform;
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            palyerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (!palyerInSightRange && !playerInAttackRange) Patrolling();
            if (palyerInSightRange && !playerInAttackRange) ChasePlayer();
            if (palyerInSightRange && playerInAttackRange) AttackPlayer();
        }

        private void Patrolling()
        {
            if (!walkPointSet) SearchWalkPoint();

            if (walkPointSet)
                agent.SetDestination(walkPoint);

            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            if (distanceToWalkPoint.magnitude < 1f)
                walkPointSet = false;
        }

        private void SearchWalkPoint()
        {
            float randomZ = Random.Range(-walkPointRange, walkPoint);
            float randomX = Random.Range(-walkPointRange, walkPoint);

            walkPoint = new Vector3(transform.position.x + randomX, transform.position.y,
                transform.position.z + randomZ);

            if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
                walkPointSet = true;
        }

        private void ChasePlayer()
        {
            agent.SetDestination(player.position); 
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void AttackPlayer()
        {
            agent.SetDestination(transform.position);
            transform.LookAt(player);

            if (!alreadyAttacked)
            {
                //ATTACK
                
                
                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }

        private void ResetAttack()
        {
            alreadyAttacked = false;
        }

        void TakeDamage(int damage)
        {
            agentHealth -= damage;
            if (agentHealth  <= 0) Invoke(nameof(DestroyEnemy), .5f);
        }

        private void DestroyEnemy()
        {
            Destroy(gameObject);
        }
    }
}