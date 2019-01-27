using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movement : MonoBehaviour
{
    private Terrain terrain;
    private NavMeshAgent agent;
    float minX, minZ, maxX, maxZ;
    private GameObject mainPlayer;
    public NavMeshAgent[] followChain = new NavMeshAgent[7];
    int x = 0;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject landscape = GameObject.Find("Terrain");
        terrain = landscape.GetComponent<Terrain>();
        mainPlayer = GameObject.Find("Player");

    }
    float i = 1.0f;
    int i2 = 5;
    // Update is called once per frame
    void Update()
    {
        double distance = Vector3.Distance(transform.position, mainPlayer.transform.position);

        if (distance <= 10)
        {
            for (x = 0; x < followChain.Length; x++)
            {
                if (x == 0)
                {
                    agent.SetDestination(mainPlayer.transform.position + new Vector3(-1, 0, 0));
                    transform.LookAt(mainPlayer.transform.position);
                }
                else
                {
                    agent.SetDestination(followChain[x - 1].transform.position + new Vector3(-1, 0, 0));
                    transform.LookAt(agent.destination);
                }
            }
        }
        else
        {
            i -= Time.deltaTime;
            if (i <= 0.0f)
            {
                i = 1.0f;
                if (i2 == 0)
                {
                    i2 = 5;
                    Vector3 three = new Vector3(Random.Range(terrain.terrainData.bounds.min.x, terrain.terrainData.bounds.max.x), 0 , Random.Range(terrain.terrainData.bounds.min.z, terrain.terrainData.bounds.max.z));


                    agent.SetDestination(three);
                    transform.LookAt(three);
                }

                i2--;

            }
        }
    }
}
