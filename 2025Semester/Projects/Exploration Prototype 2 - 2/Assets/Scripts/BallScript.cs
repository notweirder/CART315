using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private int hDir, vDir;
    public float ballSpeed = 20;

    private int[] dirOptions = { -1, 1 };

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "LeftWall") {
            // give points to Player 2
            Reset();
        }
        if (other.gameObject.name == "RightWall") {
            // give points to Player 1
            Reset();
        }
    }

    public void Reset()
    {
        rb.linearVelocity = Vector2.zero;
        transform.localPosition = new Vector3(0, 0,0);
        StartCoroutine("Launch");
    }

    private IEnumerator Launch()
    {
        
        // Figure out directions
        hDir = dirOptions[Random.Range(0, dirOptions.Length)];
        vDir = dirOptions[Random.Range(0, dirOptions.Length)];
        
        yield return new WaitForSeconds(1.5f);

        // Add a horizontal force
        rb.AddForce(transform.right * ballSpeed * hDir); // Randomly go Left or Right
        // Add a vertical force
        rb.AddForce(transform.up * ballSpeed * vDir); // Randomly go Up or Down
        
        yield return null;
    }
}
