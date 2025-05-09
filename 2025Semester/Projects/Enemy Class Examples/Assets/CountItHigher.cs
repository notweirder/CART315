 using System.Collections;

 using System.Collections.Generic;

 using UnityEngine;



 public class CountItHigher : MonoBehaviour {



     private int        _num = 0;                                        // a



     void Update() {

        Debug.Log( "The next num is: " + nextNum );

    }



public int nextNum {                                                // b

        get {

           _num++;       // Increase the value of _num by 1

           return _num;  // Return the new value of _num

       }

    }



public int currentNum {                                             // c

        get { return _num;  }                                           // d



        set { _num = value; }                                           // d

    }



// void Start() {…}  // Please delete the unused Start() method     // e

}