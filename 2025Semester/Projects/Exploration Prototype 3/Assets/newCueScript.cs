using UnityEngine;

public class newCueScript : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float angle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            angle++;
            rb2d.MoveRotation(angle);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            angle--;
            rb2d.MoveRotation(angle);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb2d.AddForce(transform.up * 100);
        }
    }
    
}
