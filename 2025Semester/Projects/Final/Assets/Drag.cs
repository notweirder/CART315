using System;
using UnityEngine;


//code taken from https://www.youtube.com/watch?v=izag_ZHwOtM
public class Drag : MonoBehaviour
{
    public bool dragging;
    public bool isPlaced;

    private Vector3 offset;

    private SpriteRenderer sr;

    private BoxCollider2D bc2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        isPlaced = false;
        dragging = false;
        sr = GetComponent<SpriteRenderer>();
        bc2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseDown()
    {
        if (!isPlaced)
        {
            sr.sortingOrder = 1;
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragging = true;
            bc2D.enabled = false;
            transform.localScale = new Vector3(4, 4, 1);
        }
    }

    private void OnMouseUp()
    {
        isPlaced = true;
        dragging = false;
        sr.sortingOrder = -1;
        bc2D.enabled = true;
        transform.localScale = new Vector3(3, 3, 1);
    }
}
