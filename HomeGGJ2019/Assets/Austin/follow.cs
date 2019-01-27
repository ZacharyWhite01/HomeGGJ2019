using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class follow : MonoBehaviour
{
    public movement move;
    NavMeshAgent[] animalsArray;
    // Start is called before the first frame update
    void Start()
    {
        animalsArray = move.followChain;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
