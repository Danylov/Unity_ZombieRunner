using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float chaseRange = 5f;
    [SerializeField] private float turnSpeed = 5f;
    
    private Transform target;
    private NavMeshAgent navMeshAgent;
    private EnemyHealth enemyHealth;
    private float distanceToTarget = Mathf.Infinity;
    private bool isProvoked = false;

    private void Start()
    {
        target = FindObjectOfType<PlayerHealth>().transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        if (enemyHealth.IsDead)
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked) EngageTarget();
        else if (distanceToTarget <= chaseRange)  isProvoked = true;
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (navMeshAgent.stoppingDistance <= distanceToTarget) ChaseTarget();
        if (distanceToTarget <= navMeshAgent.stoppingDistance) AttackTarget();
        
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        if (navMeshAgent.enabled)  navMeshAgent.SetDestination(target.position);
    }
    
    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }
  
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}