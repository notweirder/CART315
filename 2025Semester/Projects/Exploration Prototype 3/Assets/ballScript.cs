using System;
using UnityEngine;
using Random = System.Random;

public class ballScript : MonoBehaviour
{
    public int score;
    
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 10;

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided!");
        if (other.gameObject.CompareTag("Pocket"))
        {
            GameManager.S.score++;
            Debug.Log(GameManager.S.score);
            Destroy(gameObject);
        }
    }
}
