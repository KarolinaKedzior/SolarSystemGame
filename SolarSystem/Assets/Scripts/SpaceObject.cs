using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SpaceObject : MonoBehaviour {

    private string PrefabName { get; set; }
        private string InstanceName { get; set; }

        private double OrbitalPeriod { get; set; }
        private double Id { get; set; }
        private double Diameter { get; set; }
        private double Mass { get; set; }
        private double AU { get; set; }
        public double Radius;
        private double EscapeVelocity { get; set; }
        private double Inclination { get; set; }
        private double MeanOrbitalVelocity { get; set; }

    
    public Toggle toggle;
    public string Name;
    //float nextTime = 0;
    Vector3d prevVelocity, prevPosition;
    Vector3 rotationVelocity;
     public Slider slider;

    private Vector3d  acceleration, defaultPosition, defaultVelocity;
    public Vector3d worldPosition, velocity;
    private GameObject[] allSpaceObjects;

    public void MyInitialize(string instanceNameIn, string prefabNameIn, int idIn,
        double orbitalPeriodIn,
        double diameterIn,
        double massIn,
        double escapeVelocityIn,
        double inclinationIn,
        double meanOrbitalVelocity, 
        Vector3d positionIn,
        Vector3d velocityIn )
    {
        InstanceName = instanceNameIn;
        PrefabName =  prefabNameIn;
        Id = idIn;
        OrbitalPeriod = orbitalPeriodIn;
        Diameter = diameterIn;
        Mass = massIn;
        EscapeVelocity = escapeVelocityIn;
        Inclination = inclinationIn;
        MeanOrbitalVelocity = escapeVelocityIn;
        defaultPosition = positionIn;
        worldPosition = positionIn;
        velocity = velocityIn;
        defaultVelocity = velocityIn;
        acceleration = new Vector3d(0,0,0);
        toggle = GameObject.FindObjectOfType<Toggle>();
        slider = GameObject.FindObjectOfType<Slider>();
        gameObject.tag = "SpaceObject";
        
    }

    public void DebugLogPrint()
    {
        Debug.Log("Velocity" + gameObject.GetComponent<SpaceObject>().velocity);
        Debug.Log("Position" + gameObject.GetComponent<SpaceObject>().worldPosition);
        Debug.Log("Mass" + gameObject.GetComponent<SpaceObject>().Mass);
        Debug.Log("Acceleration" + gameObject.GetComponent<SpaceObject>().acceleration);
    }
    // Use this for initialization
    void Awake () {
        
       
        rotationVelocity = new Vector3(0,1f,0);
        allSpaceObjects = GameObject.FindGameObjectsWithTag("SpaceObject");
    }


  

    public void ResetPosition()
    {

       // transform.position = defaultPosition;
       //// worldPosition = (transform.position / 100) * SpaceParameters.AU;
       // acceleration = new Vector3d();
       // velocity = defaultVelocity;  
    }
  
    void Update () {

        if (toggle.isOn) { 
            SelfRotate();
            UpdatePosition();
        }
        // nextTime += interval;



    }
    private void FixedUpdate()
    {
        // Debug.Log("Fixed");

    }
    
    private void UpdatePosition()
    {
        prevPosition = worldPosition;
        prevVelocity = velocity;
       
        CalculateNext(ref worldPosition, prevVelocity);
        CalculateAcceleration();
        CalculateNext(ref velocity, acceleration);

        transform.position = (Vector3) worldPosition;
     }
    private void CalculateNext(ref Vector3d vectorIn, Vector3d multiplayer)
    {
        vectorIn += multiplayer * SpaceParameters.E_DAY_N *slider.value;//Time.deltaTime*6600000;
       
    }
    private void CalculateAcceleration()
    {
        double radius = 0;

        for (int i = 0; i < allSpaceObjects.Length; i++)
        {
            if (gameObject != allSpaceObjects[i])
            {
                radius = Vector3d.Distance(prevPosition, allSpaceObjects[i].
                    GetComponent<SpaceObject>().prevPosition);

                double temp = Mathd.Pow(radius, 3);
                //double temp2 = prevPosition.x - allSpaceObjects[i].GetComponent<SpaceObject>().prevPosition.x;
                //double temp3 = -SpaceParameters.G_N *
                //    allSpaceObjects[i].GetComponent<SpaceObject>().Mass
                //    * (prevPosition.x - allSpaceObjects[i].GetComponent<SpaceObject>().prevPosition.x);
                acceleration.x = -SpaceParameters.G_N *
                    allSpaceObjects[i].GetComponent<SpaceObject>().Mass
                    * (prevPosition.x - allSpaceObjects[i].GetComponent<SpaceObject>().prevPosition.x) / temp
                   ;

                acceleration.y = -SpaceParameters.G_N *
                  allSpaceObjects[i].GetComponent<SpaceObject>().Mass
                  * (prevPosition.y - allSpaceObjects[i].GetComponent<SpaceObject>().prevPosition.y) /
                  temp;

                acceleration.z = -SpaceParameters.G_N *
                  allSpaceObjects[i].GetComponent<SpaceObject>().Mass
                  * (prevPosition.z - allSpaceObjects[i].GetComponent<SpaceObject>().prevPosition.z) /
                  temp;
            }
        }
    }
    private void SelfRotate()
    {
        transform.Rotate(rotationVelocity);

    }

   
}
