using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonManager : MonoBehaviour
{
    public bool isWinter = false;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x <= 350f)
        {
            isWinter = true;
        }
        else
        {
            isWinter = false;
        }
    }
}
