﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BreakoutBall : MonoBehaviour
{
    private Rigidbody2D rb;
    public float ballSpeed;
    public float maxSpeed = 10f;
    public float minSpeed = 2f;

    public AudioSource scoreSound, blip;

    private bool gameRunning;
    
    private int[] dirOptions = {-1, 1};
    private int   hDir;
    
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        Reset(); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameRunning) StartCoroutine("Launch");

       
    }

    // Start the Ball Moving
    private IEnumerator Launch()
    {
        gameRunning = true;
        // Figure out directions
        hDir = dirOptions[Random.Range(0, dirOptions.Length)];
        // Add a horizontal force
        rb.AddForce(transform.right * ballSpeed * hDir); // Randomly go Left or Right
        // Add a vertical force
        rb.AddForce(transform.up*-1f); // go Down
        
        yield return null;
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        ballSpeed = 2;
        transform.position = new Vector2(0, -2);
        gameRunning = false;
    }
    
    // if the ball goes out of bounds
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        
        // did we hit a wall?
        if (other.gameObject.tag == "Wall")
        {
            // make pitch lower
            blip.pitch = 0.75f;
            blip.Play();
            SpeedCheck();
        }

        // did we hit a paddle?
        if (other.gameObject.tag == "Paddle")
        {
            // make pitch higher
            blip.pitch = 1f;
            blip.Play();
            SpeedCheck();
        }
        
        // did we hit the left Wall?
        if (other.gameObject.tag == "Reset")
        {
            GameManager.S.LoseLife();
            Reset();
        }
        
        // did we hit the left Wall?
        if (other.gameObject.tag == "Brick")
        {
            int r = Random.Range(10, 20);
            GameManager.S.AddPoint(r);
            Destroy(other.gameObject);
        }
    }

    private void SpeedCheck() {
        
        // Prevent ball from going too fast
        if (Mathf.Abs(rb.velocity.x) > maxSpeed) rb.velocity = new Vector2(rb.velocity.x * 0.99f, rb.velocity.y);
        if (Mathf.Abs(rb.velocity.y) > maxSpeed) rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.99f);

        if (Mathf.Abs(rb.velocity.x) < minSpeed)
        {
            Debug.Log("too slow?");
            rb.velocity = new Vector2(rb.velocity.x * 1.1f, rb.velocity.y);
        }

        if (Mathf.Abs(rb.velocity.y) < minSpeed)
        {
            Debug.Log("too slow?");
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 1.1f);
        }


        // Prevent too shallow of an angle
        if (Mathf.Abs(rb.velocity.x) < minSpeed) {
            // shorthand to check for existing direction
            rb.velocity = new Vector2((rb.velocity.x < 0) ? -minSpeed : minSpeed, rb.velocity.y);
        }

        if (Mathf.Abs(rb.velocity.y) < minSpeed) {
            // shorthand to check for existing direction
            rb.velocity = new Vector2(rb.velocity.x, (rb.velocity.y < 0) ? -minSpeed : minSpeed);
        }
        
        Debug.Log(rb.velocity);

    }


}
