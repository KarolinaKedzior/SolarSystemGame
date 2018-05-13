using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVSceneObject : MonoBehaviour {

    public string PrefabName { get; set; }
    public string InstanceName { get; set; }
 
    public double OrbitalPeriod { get; set; }
    public double Id { get; set; }
    public double Diameter { get; set; }
    public double Mass { get; set; }
    public double AU { get; set; }
   
    public double EscapeVelocity { get; set; }
    public double Inclination { get; set; }
    public double MeanOrbitalVelocity { get; set; }
    public float X, Y, Z;
    //public string Type { get; set; }
    //public double Weigth { get; set; }
    //public double DistanceFromSun { get; set; }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
