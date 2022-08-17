using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{

    [SerializeField] private float chaseRange = 5f;
    [SerializeField] private float turnSpeed = 5;

    NavMeshAgent nawMeshAgent;
    private float distanceToTarget = Mathf.Infinity;
    private bool isProvoked = false;

    public EnemyHealth health;
    public Transform target;


    void Start()
    {
        nawMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        //target = FindObjectOfType<PlayerHealth>().tranform;
    }

    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
            nawMeshAgent.enabled = false;
        }
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }

        
    }
    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= nawMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= nawMeshAgent.stoppingDistance)
        {
           // AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        //GetComponent<Animator>().SetBool("attack", false);
        //GetComponent<Animator>().SetTrigger("move");
        nawMeshAgent.SetDestination(target.position);
    }

    //private void AttackTarget()
    //{
    //    GetComponent<Animator>().SetBool("attack", true);
    //}

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
