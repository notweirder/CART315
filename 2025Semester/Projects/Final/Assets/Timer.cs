using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private SpriteRenderer sr;

    private Color baseColor;

    private float transparency;

    private bool isInflating = true;

    private Drag myDrag;

    public int maxSpawnTime;

    public int transpTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transpTimer = 0;
        myDrag = GetComponent<Drag>();
        transparency = 0f;
        sr = GetComponent<SpriteRenderer>();
        baseColor = sr.color;
        StartCoroutine(ReduceTransparency());
        StartCoroutine(InflateDeflate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ReduceTransparency()
    {
        while (true)
        {
            
            if (myDrag.isPlaced && transpTimer>maxSpawnTime)
            {
                transparency += 0.1f;
                sr.color = baseColor - new Color(0, 0, 0, transparency);
                if (transparency >= 1f)
                {
                    Destroy(this.gameObject);
                }
            }
            if (myDrag.isPlaced)
            {
                transpTimer++;
            }
            yield return new WaitForSeconds(1f);
            
        }        
    }

    IEnumerator InflateDeflate()
    {
        while (true)
        {
            if (!myDrag.dragging && !myDrag.isPlaced)
            {
                if (isInflating && transform.localScale.x<3.5)
                {
                    transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
                }
                else
                {
                    isInflating = false;
                }

                if (!isInflating && transform.localScale.x > 3)
                {
                    transform.localScale -= new Vector3(0.011f, 0.011f, 0.011f);
                }
                else
                {
                    isInflating = true;
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
