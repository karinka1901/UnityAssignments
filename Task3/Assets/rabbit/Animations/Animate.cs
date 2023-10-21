using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animate : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent; 
    Rigidbody rb;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float motion = agent.velocity.magnitude;
        animator.SetFloat("Motion", motion);


    }
}

