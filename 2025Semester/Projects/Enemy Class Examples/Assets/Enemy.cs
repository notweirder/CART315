using System.Collections; // Included automatically but rarely used
using System.Collections.Generic; // Required for Lists & Dictionaries
using UnityEngine; // Required for Unity-specific Classes


public class Enemy : MonoBehaviour
{
    public float speed = 10f; // The speed in m/s

    public float fireRate = 0.3f; // Shots/second (Unused)


    // Update is called once per frame

    void Update()
    {
        Move();
    }


    public virtual void Move()
    {
        Vector3 tempPos = pos;


        tempPos.y -= speed * Time.deltaTime;

        pos = tempPos;
    }


    void OnCollisionEnter(Collision coll)
    {
        GameObject other = coll.gameObject;

        switch (other.tag)
        {
            case "Hero":

                // Currently not implemented (this would destroy the hero)

                break;

            case "HeroLaser":

                // Destroy this Enemy

                Destroy(this.gameObject);

                break;
        }
    }


    // This is a Property: A method that acts like a field

    public Vector3 pos
    {
        get { return this.transform.position; }

        set { this.transform.position = value; }
    }
}