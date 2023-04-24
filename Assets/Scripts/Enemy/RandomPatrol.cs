//using System.Collections;
//using UnityEngine;
//using UnityEngine.AI;

//public class RandomPatrol : MonoBehaviour
//{
//    public float patrolRadius = 10f;
//    public float patrolDelay = 3f;
//    public float sightRange = 20f;
//    private NavMeshAgent navMeshAgent;
//    private Vector3 initialPosition;
//    private Transform player;

//    private void Start()
//    {
//        navMeshAgent = GetComponent<NavMeshAgent>();
//        initialPosition = transform.position;
//        player = GameObject.FindGameObjectWithTag("Player").transform;
//        StartCoroutine(Patrol());
//    }

//    private IEnumerator Patrol()
//    {
//        while (true)
//        {
//            if (PlayerInSight())
//            {
//                navMeshAgent.SetDestination(player.position);
//                yield return new WaitForSeconds(patrolDelay);
//            }
//            else
//            {
//                Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
//                randomDirection += initialPosition;
//                NavMeshHit navMeshHit;
//                if (NavMesh.SamplePosition(randomDirection, out navMeshHit, patrolRadius, 1))
//                {
//                    navMeshAgent.SetDestination(navMeshHit.position);
//                }
//                yield return new WaitForSeconds(patrolDelay);
//            }
//        }
//    }

//    private bool PlayerInSight()
//    {
//        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
//        if (distanceToPlayer <= sightRange)
//        {
//            RaycastHit hit;
//            Vector3 directionToPlayer = (player.position - transform.position).normalized;
//            if (Physics.Raycast(transform.position, directionToPlayer, out hit, sightRange))
//            {
//                return hit.transform.CompareTag("Player");
//            }
//        }
//        return false;
//    }
//}


//using System.Collections;
//using UnityEngine;
//using UnityEngine.AI;

//public class RandomPatrol : MonoBehaviour
//{
//    public float patrolRadius = 10f;
//    public float patrolDelay = 3f;
//    private NavMeshAgent navMeshAgent;
//    private Vector3 initialPosition;

//    private void Start()
//    {
//        navMeshAgent = GetComponent<NavMeshAgent>();
//        initialPosition = transform.position;
//        StartCoroutine(Patrol());
//    }

//    private IEnumerator Patrol()
//    {
//        while (true)
//        {
//            Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
//            randomDirection += initialPosition;
//            NavMeshHit navMeshHit;
//            if (NavMesh.SamplePosition(randomDirection, out navMeshHit, patrolRadius, 1))
//            {
//                navMeshAgent.SetDestination(navMeshHit.position);
//            }
//            yield return new WaitForSeconds(patrolDelay);
//        }
//    }
//}

using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class RandomPatrol : MonoBehaviour
{
    public float patrolRadius = 10f;
    public float patrolDelay = 3f;
    public float sightRange = 20f;
    public float chasingSpeedMultiplier = 2f;
    private NavMeshAgent navMeshAgent;
    private Vector3 initialPosition;
    private Transform player;
    private float initialSpeed;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        initialPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initialSpeed = navMeshAgent.speed;
        StartCoroutine(Patrol());
    }

    private IEnumerator Patrol()
    {
        while (true)
        {
            if (PlayerInSight())
            {
                navMeshAgent.speed = initialSpeed * chasingSpeedMultiplier;
                navMeshAgent.SetDestination(player.position);
                yield return new WaitForSeconds(patrolDelay);
            }
            else
            {
                navMeshAgent.speed = initialSpeed;
                Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
                randomDirection += initialPosition;
                NavMeshHit navMeshHit;
                if (NavMesh.SamplePosition(randomDirection, out navMeshHit, patrolRadius, 1))
                {
                    navMeshAgent.SetDestination(navMeshHit.position);
                }
                yield return new WaitForSeconds(patrolDelay);
            }
        }
    }

    private bool PlayerInSight()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= sightRange)
        {
            RaycastHit hit;
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            if (Physics.Raycast(transform.position, directionToPlayer, out hit, sightRange))
            {
                return hit.transform.CompareTag("Player");
            }
        }
        return false;
    }
}

