using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))] //kiinnitt‰‰ t‰h‰n navmeshagentin eli t‰m‰ on valmiina inspectorissa
public class NawMeshMouseControls : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        SetAnimator();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);
                Debug.Log(hit.point);
            }
        }
    }

    private void SetAnimator()
    {
        if (agent.velocity.magnitude > 0.1f)  // jos agentin nopeus on > 0.1f
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isIdling", false);
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdling", true);
        }
    }
}
