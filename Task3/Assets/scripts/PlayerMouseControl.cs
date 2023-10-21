using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMouseControl : MonoBehaviour
{
    public Camera Camera;
    public NavMeshAgent agent;
    Animator anim;



    private void Start()
    {

        anim = GetComponentInChildren<Animator>();


    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
            Debug.Log("mouse clicked");
        }
        float motion = agent.velocity.magnitude;
        anim.SetFloat("Motion", motion);

    }
}



