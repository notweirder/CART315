using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class paddleScript : MonoBehaviour
{
    private Color[] colorArr = {Color.blue, Color.yellow, Color.green};
    public KeyCode upKey,downKey, leftKey, rightKey;

    public float xLoc, yLoc;

    public float speed = 0.5f;

    public float yMax;

    public int currentColor;

    private SpriteRenderer spriteRend;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
      spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(upKey) && yLoc < yMax)
        {
            yLoc+= speed;
        }

        if (Input.GetKey(downKey) && yLoc > - yMax)
        {
            yLoc-=speed;
        }

        if (Input.GetKeyDown(leftKey))
        {
            currentColor--;
        }
        if (Input.GetKeyDown(rightKey))
        {
            currentColor++;
        }

        if (currentColor >= colorArr.Length)
        {
            currentColor = 0;
        }
        
        if (currentColor < 0)
        {
            currentColor = colorArr.Length-1;
        }
        
        spriteRend.color = colorArr[currentColor];
        this.transform.position = new Vector3(xLoc, yLoc, 0);
    }
}
