using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    static public Vector3 POS = Vector3.zero; //POS = Position

    [Header("Inscribed")] 
    //max distance Attractor can move away from origin
    public Vector3 range = new Vector3(40, 10, 40);
    //frequency of sine waves (x moves 5x the frequency of z)
    //sine waves are not in perfect frequency w/each other to appear more natural
    public Vector3 phase = new Vector3(0.5f, 0.4f, 0.1f);

    private void FixedUpdate()
    {
        Vector3 tPos = transform.position;
        tPos.x = Mathf.Sin( phase.x * Time.time ) * range.x;                 
        tPos.y = Mathf.Sin( phase.y * Time.time ) * range.y;
        tPos.z = Mathf.Sin( phase.z * Time.time ) * range.z;
        transform.position = tPos;
        POS = tPos;
    }
}
