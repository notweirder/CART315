using System;
using UnityEngine;
using Pathfinding;
using Random = UnityEngine.Random;

public class CarMover : MonoBehaviour
{
    public AIDestinationSetter aiDS;
    public AIPath aiPath;
    
    private SpriteRenderer sr;

    private GameObject myDestination;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChooseRandomDestination();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        TerrainEffect(other.tag);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        SetToDefault();
    }

    private void SetToDefault()
    {
        aiPath.maxSpeed = 1;
    }

    private void TerrainEffect(string eff)
    {
        switch (eff)
        {
            case "Water":
            {
                SetSpeed(2f);
                break;
            }
            case "Mud":
            {
                SetSpeed(0.5f);
                break;
            }
            case
                "Scramble":
            {
                ChooseRandomDestination(myDestination);
                break;
            }
            case "Void":
            {
                Destroy(this.gameObject);
                break;
            }
        }
    }

    private void ChooseRandomDestination(GameObject prevDestination = null)
    {
        myDestination = GameManager.S.homes[Random.Range(0, 5)];
        if (prevDestination != null)
        {
            while (myDestination == prevDestination)
            {
                myDestination = GameManager.S.homes[Random.Range(0, 5)];
            }
        }
        sr  = GetComponent<SpriteRenderer>();
        sr.color = myDestination.GetComponent<SpriteRenderer>().color;
        aiDS.target = myDestination.transform;

    }

    private void SetSpeed(float speed)
    {
        aiPath.maxSpeed = speed;
    }
}
