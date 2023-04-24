using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class RandomPatrol : MonoBehaviour
{
    public float patrolRadius = 10f;
    public float patrolDelay = 3f;
    private NavMeshAgent navMeshAgent;
    private Vector3 initialPosition;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        initialPosition = transform.position;
        StartCoroutine(Patrol());
    }

    private IEnumerator Patrol()
    {
        while (true)
        {
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
