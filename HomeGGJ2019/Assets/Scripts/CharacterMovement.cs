using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterMovement : MonoBehaviour
{
    Camera cam;
    public LayerMask movementMask;
    NavMeshAgent agent;
    Animator anim;
    Vector3 destination;
    bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                destination = hit.point;
                agent.SetDestination(destination);
            }
        }
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            isWalking = false;

        }
        else
        {
            isWalking = true;
        }
        anim.SetBool("Walking", isWalking);
    }
}
