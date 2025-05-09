using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionsEx : MonoBehaviour
{
    public int numTimesCalled = 0; //a

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numTimesCalled++; // b
        PrintUpdates(); // c
    }
    void PrintUpdates()         // d
    {
        string outputMessage = "Updates: " + numTimesCalled; // e
        print(outputMessage); // Output example: "Updates: 1"        // f
    }
}