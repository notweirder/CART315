using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject ballPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        Instantiate(ballPrefab, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ballPrefab.GetComponent<Transform>().transform.position);
        // if (myBall.transform.position.x < -10 || myBall.transform.position.x > 10)
        // {
        //     Destroy(myBall);
        // }
    }
}
