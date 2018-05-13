using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_Init : MonoBehaviour {

    int interval = 1;
    float nextTime = 0;
    // Use this for initialization
    void Start () {
        gameObject.GetComponent<SpaceObject>().MyInitialize(
            SpaceParameters.E_MASS_N,
            new Vector3d(SpaceParameters.AU_N, 0, 0),
            new Vector3d(0, 0, SpaceParameters.E_SPEED_N)
            );
       
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= nextTime)
        {

            gameObject.GetComponent<SpaceObject>().DebugLogPrint();

            nextTime += interval;

        }
       


    }
}
