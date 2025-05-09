using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class TerrainEffectSpawner : MonoBehaviour
{
    private float xRange, yRange;
    public GameObject[] terrainEffect = new GameObject[4];

    public int maxAmount;

    public int spawnRate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnTerrainEffect());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTerrainEffect()
    {
        xRange = Random.Range(-6.5f, 6.5f);
        yRange = Random.Range(-3f, 3f);

        if (transform.childCount < maxAmount)
        {
            Instantiate(terrainEffect[Random.Range(0,4)], new Vector3(xRange, yRange, 0), quaternion.identity, this.transform);

        }
        yield return new WaitForSeconds(spawnRate);

        StartCoroutine(SpawnTerrainEffect());
    }
}
