using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSet : MonoBehaviour
{
    public GameObject[] animalPlacements;

    // Start is called before the first frame update
    void Start()
    {
        if (animalPlacements == null)
            animalPlacements = GameObject.FindGameObjectsWithTag("AnimalPlacements");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < animalPlacements.Length; i++)
        {
            //animalPlacements[i].GetComponent<>().isTrue;
        }
    }
}
