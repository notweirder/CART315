using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //allows class to be seen/edited in the unity browser
public class BoidSettings //does not extend MonoBehavior, therefore can be used in script in addition to MonoBehavior script
{
    //These fields allow you to adjust the flocking behaviour of the boids
    public int velocity = 32;
    public int neighborDist = 10;
    public int nearDist = 4;
    public int attractPushDist = 5;

    [Header("These \"influences\" are floats, usually from [0...4]")]
    public float velMatching = 1.5f;

    public float flockCentering = 1f;
    public float nearAvoid = 2f;
    public float attractPull = 1f;
    public float attractPush = 20f;

    [Header("This determines how quickly Boids can turn and is [0...1'")]
    public float velocityEasing = 0.03f;
}

public class Spawner : MonoBehaviour //main script
    {
        //SETTINGS and BOIDS are both static to allow easy access
        static public BoidSettings SETTINGS; //Instance of BoidSettings class above, allows Boid to access settings
        static public List<Boid> BOIDS; //list of Boid objects
        
        //These fields allow you to adjust the spawning behaviour of the Boids
        [Header("Inscribed: Settings for Spawning Boids")]
        public GameObject boidPrefab;
        public Transform boidAnchor; //
        public int numBoids = 100;
        public float spawnRadius = 100f;
        public float spawnDelay = 0.1f;

        [Header("Inscribed: Settings for Spawning Boids")]
        public BoidSettings boidSettings;

        void Awake()
        {
            Spawner.SETTINGS = boidSettings;
            BOIDS = new List<Boid>();
            InstantiateBoid();
        }

        public void InstantiateBoid()
        {
            GameObject go = Instantiate<GameObject>(boidPrefab); //instantiates gameobject 
            go.transform.position = Random.insideUnitSphere * spawnRadius; //sets position of boidPrefab to be anywhere in a sphere between the size of [0,0,0] and [100,100,100]
            Boid b = go.GetComponent<Boid>(); 
            b.transform.SetParent(boidAnchor); //uses the Boid script to set the parent of the Boid prefab to be boidAnchor
            BOIDS.Add(b);
            if (BOIDS.Count < numBoids)
            {
                Invoke("InstantiateBoid",spawnDelay); //runs function every [x] seconds (spawnDelay)
            }
        }
    }

