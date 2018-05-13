using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SpaceObject : MonoBehaviour {

    public string Name;
    float nextTime = 0;
    Vector3d prevVelocity, prevPosition;
    public double  Radius;
    private double Mass;
    Vector3 rotationVelocity;
    public bool isPreDefined  = false;
    public Slider slider;

    private Vector3d  acceleration, defaultPosition, defaultVelocity;
    public Vector3d worldPosition, velocity;
    private GameObject[] allSpaceObjects;

    public void MyInitialize(double massIn, Vector3d positionIn, Vector3d velocityIn )
    {
        gameObject.GetComponent<SpaceObject>().Mass = massIn;
        gameObject.GetComponent<SpaceObject>().defaultPosition = positionIn;
        gameObject.GetComponent<SpaceObject>().worldPosition = positionIn;
        gameObject.GetComponent<SpaceObject>().velocity = velocityIn;
        gameObject.GetComponent<SpaceObject>().defaultVelocity = velocityIn;
        gameObject.GetComponent<SpaceObject>().acceleration = new Vector3d(0,0,0);
        
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
        
        if(Name == "Sun")
        {

            gameObject.GetComponent<SpaceObject>().MyInitialize(
                SpaceParameters.S_MASS_N,
                new Vector3d(0, 0, 0),
                new Vector3d(0, 0, 0)
                );

        }
        else
        {
            gameObject.GetComponent<SpaceObject>().MyInitialize(
            SpaceParameters.E_MASS_N,
            new Vector3d(SpaceParameters.AU_N, 0, 0),
            new Vector3d(0, 0, SpaceParameters.E_SPEED_N)
            );
        }
        rotationVelocity = new Vector3(0,1f,0);
        allSpaceObjects = GameObject.FindGameObjectsWithTag("SpaceObject");
    }


    private Vector3d ScaleCoordinates(Vector3d Wposition)
    {
        //float xMIN, xMAX = 200;
        //xMIN = -xMAX;
        //Vector3d X0 = Vector3d.one * -SpaceParameters.AU * 2;
        //float Sx = (xMAX - xMIN) / (SpaceParameters.AU * 4.0f);
        //return ((Wposition - X0) * Sx) + (xMIN * Vector3d.one);
        return new Vector3d();
    }

    public void ResetPosition()
    {

       // transform.position = defaultPosition;
       //// worldPosition = (transform.position / 100) * SpaceParameters.AU;
       // acceleration = new Vector3d();
       // velocity = defaultVelocity;  
    }
  
    void Update () {
        

            SelfRotate();
            UpdatePosition();

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
       // transform.position = worldPosition ;
      //  transform.localPosition = ScaleCoordinates(worldPosition);
      //  Debug.Log(velocity);
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
                double temp2 = prevPosition.x - allSpaceObjects[i].GetComponent<SpaceObject>().prevPosition.x;
                double temp3 = -SpaceParameters.G_N *
                    allSpaceObjects[i].GetComponent<SpaceObject>().Mass
                    * (prevPosition.x - allSpaceObjects[i].GetComponent<SpaceObject>().prevPosition.x);
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
