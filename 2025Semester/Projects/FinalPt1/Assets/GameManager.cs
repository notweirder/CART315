using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager S;
    public GameObject[] homes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        S = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
