using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVSceneObject  {

    public string PrefabName { get; set; }
    public string InstanceName { get; set; }
 
    public double OrbitalPeriod { get; set; }
    public int Id { get; set; }
    public double Diameter { get; set; }
    public double Mass { get; set; }
    public double AU { get; set; }
   
    public double EscapeVelocity { get; set; }
    public double Inclination { get; set; }
    public double MeanOrbitalVelocity { get; set; }
    public float X, Y, Z;
    public double Vx, Vy, Vz;



}
