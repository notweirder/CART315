using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarSpawner : MonoBehaviour
{
    public GameObject myCar;

    public Transform[] spawnLocations;

    private GameObject go;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnLocations = new Transform[10];
        
        go = this.gameObject;
        //Instantiate(myCar, new Vector3(1.5f, 1, 0), quaternion.identity);
        for (int i = 0; i < transform.childCount; i++)
        {
            spawnLocations[i] = transform.GetChild(i).transform;
            Debug.Log(spawnLocations[i]);
        }
        StartCoroutine(SpawnCar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnCar()
    {
        Instantiate(myCar, spawnLocations[Random.Range(0,spawnLocations.Length-1)].position, quaternion.identity,this.transform);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SpawnCar());
    }
}
