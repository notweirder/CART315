using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefabVar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject cubeGO = Instantiate<GameObject>(cubePrefabVar);
        Material mat = cubeGO.GetComponent<Renderer>().material;
        mat.color = Random.ColorHSV(0, 1, 0.5f, 1, 0.75f, 1);
    }
}