using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float chaseRange = 10f;
    private NavMeshAgent navMeshAgent;
    private float distanceToTarget = Mathf.Infinity;
    private bool isProvoked = false;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked) EngageTarget();
        else if (distanceToTarget <= chaseRange)  isProvoked = true;
    }

    private void EngageTarget()
    {
        if (navMeshAgent.stoppingDistance <= distanceToTarget) ChaseTarget();
        if (distanceToTarget <= navMeshAgent.stoppingDistance) AttackTarget();
        
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }
    
    private void AttackTarget()
    {
        Debug.Log(name + " has seeked and destroying " + target.name);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}