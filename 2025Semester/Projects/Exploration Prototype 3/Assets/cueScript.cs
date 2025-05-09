using System;
using System.Collections;
using UnityEngine;

public class cueScript : MonoBehaviour
{
    private Vector3 mouseVector3, mouseVector3Local;
    
    public float angleMouse;
    public float angleIncrease;

    private Camera cam;
    private Rigidbody2D rb;
    private HingeJoint2D hj;

    public float angle;

    public int mSpeed;
    private JointMotor2D motor;

    public Transform anchor;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // hj = GetComponent<HingeJoint2D>();
        // JointMotor2D motor = new JointMotor2D();
        // motor.motorSpeed = mSpeed;
        // motor.maxMotorTorque = 100000;
        // hj.motor = motor;
        // hj.useMotor = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        //mSpeed = 0;
        if (Input.GetKey("up"))
        {
            transform.RotateAround(anchor.position, Vector3.forward, angle);
            //mSpeed = 100;
        }
         if (Input.GetKey("down"))
        {
            transform.RotateAround(anchor.position, Vector3.forward, -angle);
           // mSpeed = -100;
        }
        
        // motor.motorSpeed = mSpeed;
        // motor.maxMotorTorque = 100000;
        //
        // hj.motor = motor;
        //
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * 20);
        }

    }

     void FixedUpdate()
    {
        Debug.Log(rb.linearVelocity);
    }

     void OnCollisionEnter2D(Collision2D other)
    {
        rb.linearVelocity = Vector2.zero;
        Debug.Log("A");
        Debug.Log(other.relativeVelocity);
    }
    
}


