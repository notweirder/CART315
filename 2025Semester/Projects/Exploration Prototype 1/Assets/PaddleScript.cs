using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float zRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && zRotation<=25)
        {
            zRotation+=0.2f;
        }
        if (Input.GetKey(KeyCode.D) && zRotation>=-25)
        {
            zRotation-=0.2f;
        }

        this.transform.rotation = Quaternion.Euler(0, 0, zRotation);
    }
}
