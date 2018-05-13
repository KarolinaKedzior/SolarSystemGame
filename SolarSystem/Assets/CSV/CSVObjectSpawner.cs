using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LINQtoCSV;
using System.IO;
using System.Linq;

public class CSVObjectSpawner : MonoBehaviour {

    private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();
    [Tooltip("Prefabs for each objects")]
    public GameObject[] gameObjects;

    [Tooltip("The file that contains the object to be spawned in this scene")]
    public TextAsset sceneDescriptor;

    private void Awake()
    {
        foreach (var obj in gameObjects) 
        {
            prefabs[obj.name] = obj;
        }
    }
    // Use this for initialization
    void Start () {
        CsvFileDescription inputFileDescription = new CsvFileDescription
        {
            SeparatorChar = ',',
            FirstLineHasColumnNames = true
        };
       

        using(var ms = new MemoryStream())
        {
            using(var txtWriter = new StreamWriter(ms))
            {
                using (var txtReader = new StreamReader(ms))
                {
                    txtWriter.Write(sceneDescriptor.text);
                    txtWriter.Flush();
                    ms.Seek(0, SeekOrigin.Begin);

                    //Read data from csv file
                    CsvContext cc = new CsvContext();

                    var list = cc.Read<CSVSceneObject>(txtReader, inputFileDescription).Where<CSVSceneObject>(x => x.PrefabName == "Sphere");
                    foreach (var so in list)
                    {

                  
                                        GameObject copy = Instantiate(prefabs[so.PrefabName]);
                                        copy.name = so.InstanceName;
                                        copy.transform.position = new Vector3(so.X, so.Y, so.Z);
                                    } ;


                    //Runs through all object taht will 
                }
                 

            }
        }
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
