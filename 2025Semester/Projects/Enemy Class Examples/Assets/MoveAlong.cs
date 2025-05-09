using System.Collections;

using System.Collections.Generic;

using UnityEngine;

 

public class MoveAlong : MonoBehaviour {

 



    private CountItHigher cih;                                               // a

 

    void Start() {

        cih = this.gameObject.GetComponent<CountItHigher>();                 // b

        if ( cih == null ) {                                                 // c

            Debug.LogWarning("No CountItHigher component on GameObject "+name);

        }

    }

    

    void LateUpdate() {                                                      // d

        if ( cih == null ) return;                                           // e



        float tX = cih.currentNum / 10f;                                     // f

        Vector3 tempLoc = pos;                                               // g

        tempLoc.x = tX;

        pos = tempLoc;

    }

 

    public Vector3 pos {                                                     // h

        get { return( transform.position ); }

        set { transform.position = value;   }

    }

 

}