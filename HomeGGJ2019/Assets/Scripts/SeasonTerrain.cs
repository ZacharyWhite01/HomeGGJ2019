using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Projector))]
public class SeasonTerrain : MonoBehaviour
{
    Projector projector;
    float maxClipPlane = 30f;
    float minClipPlane = 0.02f;

    public SeasonManager seasonManager;
    bool isWinter;

    // Start is called before the first frame update
    void Start()
    {
        projector = GetComponent<Projector>();
        projector.enabled = false;
        isWinter = seasonManager.isWinter;
    }

    // Update is called once per frame
    void Update()
    {
        isWinter = seasonManager.isWinter;
        if (isWinter)
        {
            projector.enabled = true;
            if (projector.farClipPlane <= maxClipPlane)
            {
                projector.farClipPlane += 5 * Time.deltaTime;
            }
        }

        if (!isWinter)
        {
            projector.farClipPlane -= 5 * Time.deltaTime;
            if (projector.farClipPlane <= minClipPlane)
            {
                projector.enabled = false;
            }
        }
    }
}
