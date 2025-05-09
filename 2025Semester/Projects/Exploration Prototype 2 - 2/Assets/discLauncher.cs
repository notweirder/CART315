using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
public class discLauncher : MonoBehaviour
{
    private Rigidbody2D rb;
    

    public float speedY,speedYMax,rateOfChange,speedIncreaseRate;

    public float speedYTemp;

    private int score;

    private bool hasBeenLaunched, hasScoreBeenCalculated;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (speedY > 0)
        {
            rb.linearVelocityY = speedY;
            speedY -= rateOfChange;
        }
        else
        {
            speedY = 0;
            rb.linearVelocityY = 0;
        }

        if (Input.GetMouseButton(0) && speedYTemp < speedYMax && !hasBeenLaunched)
        {
            speedYTemp += speedIncreaseRate;
        }

        if (Input.GetMouseButtonUp(0))
        {
            speedY = speedYTemp;
            hasScoreBeenCalculated = false;
            hasBeenLaunched = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (hasBeenLaunched && speedY == 0 && hasScoreBeenCalculated == false) 
        {
            Debug.Log(other.gameObject.name);
            switch (other.gameObject.name)
            {
                case "Easy":
                    score += 1;
                    break;
                case "Medium":
                    score += 2;
                    break;
                case "Hard":
                    score += 3;
                    break;
                default:
                    break;
            }

            hasScoreBeenCalculated = true;
            hasBeenLaunched = false;
            speedYTemp = 0;
            Debug.Log(" Score: " + score);
            StartCoroutine(Reset());
        }

    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(2);
        transform.localPosition = new Vector3(0,-4,0);
    }
}
