using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDropperScript : MonoBehaviour
{
    public GameObject circle;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DropBalls());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator DropBalls()
    {
        while (true)
        {
            Color32[] colorsArray =
            {
                new Color32(146, 37, 186,255), //purple
                new Color32(50, 104, 168,255) //blue
            };
            string[] tagArray =
            {
                "LeftZone",
                "RightZone"
            };
            int randomInt = Random.Range(0, 2);
            Vector3 loc = new Vector3(0, 5, 0);
            GameObject circ = Instantiate(circle, loc, transform.rotation);
            Renderer rend = circ.GetComponent<Renderer>();
            rend.material.color = colorsArray[randomInt];
            circ.tag = tagArray[randomInt];
            yield return new WaitForSeconds(2f);
        }
    }
}