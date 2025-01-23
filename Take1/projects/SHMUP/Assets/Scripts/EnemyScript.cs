using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float ballSpeed;
    private float   hDir, vDir;
    // Start is called before the first frame update
    void Start()
    {   rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Launch");
        Reset();


    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private IEnumerator Launch() {
        yield return new WaitForSeconds(0f);


        hDir = Mathf.Round(Random.Range(-5f, 5f)) /10f;
        vDir = Mathf.Round(Random.Range(-5f, 5f)) / 10f;
        // Figure out directions
        
        if (hDir == 0f && vDir == 0f)
        {
            hDir = 0.1f;
            vDir = 0.1f;
        }

        print(hDir);
        print(vDir);
        rb.velocity = new Vector2(ballSpeed * hDir, ballSpeed * vDir).normalized;

        
        
        yield return null;
    }
    
    public void Reset()
    {        
        ballSpeed = 1f;
        transform.position = new Vector2(0, 0).normalized;
        StartCoroutine("Launch");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {

            Destroy(this.gameObject);
        }
    }
    

    
}
