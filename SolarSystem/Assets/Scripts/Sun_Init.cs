using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun_Init : MonoBehaviour {

	// Use this for initialization
	void Start () {
      
        gameObject.GetComponent<SpaceObject>().MyInitialize(
            SpaceParameters.S_MASS_N,
            new Vector3d(0,0,0),
            new Vector3d(0,0,0)
            ) ;
        
         
    }
    
	
	// Update is called once per frame
	void Update () {
		
	}
}
