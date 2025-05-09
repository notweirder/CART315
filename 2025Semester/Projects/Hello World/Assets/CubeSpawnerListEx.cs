using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeSpawnerListEx : MonoBehaviour
{
    public GameObject cubePrefabVar;

    public List<GameObject> gameObjectList; // Will hold all the Cubes

    [Tooltip("This is the amount that a cube will shrink each frame.")] // a
    public float scalingFactor = 0.95f;

    public int numCubes = 0; // Total # of Cubes instantiated


    // Start is called before the first frame update

    void Start()
    {
        // This initializes the List<GameObject>

        gameObjectList = new List<GameObject>();
    }


    // Update is called once per frame

    void Update()
    {
        numCubes++; // Add to the number of Cubes                            // b


        GameObject gObj = Instantiate<GameObject>(cubePrefabVar); // c


        // These lines set some values on the new Cube

        gObj.name = "Cube " + numCubes; // d

        Color c = new Color(Random.value, Random.value, Random.value); // e

        gObj.GetComponent<Renderer>().material.color = c;

        // ^ Gets the Renderer of gObj & gives its Material a random color

        gObj.transform.position = Random.insideUnitSphere; // f


        gameObjectList.Add(gObj); // Add gObj to the List of Cubes


        List<GameObject> removeList = new List<GameObject>(); // g

        // ^ This removeList will store information on Cubes that should be

        //    removed from gameObjectList


        // Iterate through each Cube in gameObjectList 

        foreach (GameObject goTemp in gameObjectList)
        {
            // h

            // Get the scale of the Cube

            float scale = goTemp.transform.localScale.x; // i

            scale *= scalingFactor; // Shrink it by the scalingFactor

            goTemp.transform.localScale = Vector3.one * scale;


            if (scale <= 0.1f)
            {
                // If scale is less than 0.1f...          // j

                removeList.Add(goTemp); // ...then add it to removeList
            }
        }


        foreach (GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); // k

            // ^ Remove the Cube from gameObjectList

            Destroy(goTemp); // Destroy the Cube’s GameObject
        }
    }
}