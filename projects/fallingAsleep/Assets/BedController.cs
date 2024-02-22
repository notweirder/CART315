using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BedController : MonoBehaviour
{
    private SpriteRenderer sr;

    public float xLoc = 0;
    public float bedSpeed = .01f;

    public float score;
    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        sr.color = Color.blue;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Sleepy") score += 1;
        else score -= 1;
        
        Destroy(other.gameObject);
    }
}
