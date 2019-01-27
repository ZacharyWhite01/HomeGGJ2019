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
    bool firstPerson = false;
    public int speed = 250;

    Vector3 moveDirection;

    public CameraController mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cam != null)
        {
            if (firstPerson == false)
            {
                if (agent.enabled == false)
                {
                    agent.enabled = true;
                    agent.isStopped = false;
                    agent.SetDestination(transform.position);
                    GetComponent<Rigidbody>().isKinematic = true;
                    agent.isStopped = false;
                }

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
            }

            if (firstPerson)
            {
                if (agent.enabled)
                {
                    agent.isStopped = true;
                    agent.enabled = false;
                }
                Vector3 pos = transform.position;

                float horizontalMovement = Input.GetAxis("Horizontal");
                float verticleMovement = Input.GetAxis("Vertical");

                moveDirection = (horizontalMovement * transform.right + verticleMovement * transform.forward).normalized;

                GetComponent<Rigidbody>().isKinematic = false;
                isWalking = true;
                Move();
            }
            anim.SetBool("Walking", isWalking);
        }
        else
        {
            detectCam();
        }
    }

    public void detectCam()
    {

        if (mainCamera.firstPersonCamera.gameObject.activeSelf == true)
        {
            firstPerson = true;
            cam = mainCamera.firstPersonCamera;
        }
        else if (mainCamera.topDownCamera.gameObject.activeSelf == true)
        {
            firstPerson = false;
            cam = mainCamera.topDownCamera;
        }
    }

    void Move()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 yVelocity = new Vector3(0, rb.velocity.y, 0);
        rb.velocity = moveDirection * speed * Time.deltaTime;
        rb.velocity += yVelocity;
        isWalking = false;
    }
}
