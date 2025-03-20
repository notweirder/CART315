using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public GameObject circle;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Drop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private IEnumerator Drop() 
    {
        //do something
        Debug.Log("Drop");
        float rX = Random.Range(-6f, 6f);
        Vector3 loc = new Vector3(rX, 6, 0);
        Instantiate(circle, loc, transform.rotation);
        //wait 
        float next = Random.Range(0.25f, 1.5f);
        yield return new WaitForSeconds(next);
        // go again
        StartCoroutine(Drop()); 
    }
}
