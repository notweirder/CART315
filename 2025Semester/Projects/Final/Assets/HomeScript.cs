using System;
using UnityEngine;
using Pathfinding;

public class HomeScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //  https://discussions.unity.com/t/receiving-oncollisionenter-from-child-gameobject/417358/2
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hello");
        if (other.CompareTag("Car"))
        {
            Destroy(other.gameObject);
        }
}
}
