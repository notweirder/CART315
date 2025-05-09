using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneScript : MonoBehaviour
{
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 ballPos = other.gameObject.GetComponent<Transform>().position;
        if ((other.CompareTag("LeftZone") && ballPos.x<0) || other.CompareTag("RightZone") && ballPos.x>0)
        {
            Debug.Log("correct!");
            score++;
        }
        else
        {
            Debug.Log("wrong!");
            score--;
        }
        Debug.Log("Score: " + score);
    }
}
