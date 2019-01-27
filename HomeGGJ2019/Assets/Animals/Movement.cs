using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    private NavMeshAgent block;
    private GameObject dan;
   
    void Start()
    {
        block = GetComponent<NavMeshAgent>();
        dan = GameObject.Find("Dan");

    }


    void Update()
    {
        block.SetDestination(dan.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (dan.gameObject.name == "Dan")
        {
            SceneManager.LoadScene("endGame");
        }

    }
}
// Targets name is DAN
