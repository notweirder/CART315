using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;
    private Vector3 scaleChange, positionChange;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f; // zero z
            print(mouseWorldPos.x);
            bullet.transform.localScale = new Vector3(1, 1, 1);
            Instantiate(bullet, new Vector3(mouseWorldPos.x, mouseWorldPos.y,0),Quaternion.identity,this.transform);
            //print("test");

        }
        
    }
    
}

    


