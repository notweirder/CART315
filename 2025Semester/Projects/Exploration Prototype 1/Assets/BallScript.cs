using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
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
        if (this.gameObject.CompareTag("LeftBall") && other.gameObject.CompareTag("LeftZone"))
        {
            // Debug.Log("Correct!");
            score++;
        }
        else if (this.gameObject.CompareTag("RightBall") && other.gameObject.CompareTag("RightZone"))
        {
            // Debug.Log("Correct!");
            score++;
        }
        else
        {
            Debug.Log("Wrong!");
            score--;
        }
        Debug.Log(score);
    }
}
