using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public float xLoc, yLoc;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        xLoc = 0f;
        yLoc = 0f;
        speed = 0.01f;
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            xLoc -= speed;
        }

        if (Input.GetKey(KeyCode.X))
        {
            xLoc += speed;


        }
        this.transform.position = new Vector3(xLoc, yLoc, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Circle");
        {
            Debug.Log(other.gameObject.name);
            Destroy(other.gameObject);
        }
    }
}
