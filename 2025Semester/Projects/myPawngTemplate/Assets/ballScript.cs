using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ballScript : MonoBehaviour
{
    private Rigidbody2D rb;

    public float ballSpeed = 1;

    private int[] directionsOptions = {
        -1,1
    };

    private int hDir, vDir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }

    private void OnCollisionEnter2D(Collision2D wall)
    {
        throw new NotImplementedException();
        if (wall.gameObject.name == "leftWall")
        {
            //give points to Player 2
            Reset();
        }
        if (wall.gameObject.name == "leftWall")
        {
            //give points to Player 2
            Reset();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Launch()
    {
        //choose Random X dir
        hDir = direectionOptions[Random.Range(0, directionOption.Length)];
        //choose Random Y dir
        
        //wait for X seconds
        vDir = direectionOptions[Random.Range(0, directionOption.Length)];
        yield return new WaitForSeconds(1);

        //Apply force
        rb.AddForce(transform.right * ballSpeed * hDir);
        //Vertical
        rb.AddForce(transform.up * ballSpeed * vDir);

    }

    void Reset()
    {
        //reset to 0,0
        //Launch
        StartCoroutine(Launch());
    }
    
}
