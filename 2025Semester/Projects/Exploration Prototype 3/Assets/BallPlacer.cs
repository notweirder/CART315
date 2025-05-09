using UnityEngine;



public class BallPlacer : MonoBehaviour
{
    public GameObject ball;
    public int rows;
    public float offsetX, offsetY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Place();
        transform.rotation = Quaternion.Euler(0f,0,135f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //https://stackoverflow.com/questions/48844379/unity3d-how-to-change-color-of-instantiated-prefab
    public void Place()
    {
        for (int i = rows; i >0; i--)
        {
            for (int j = rows; j > 0; j--)
            {
                float xPos = -j+i;
                //Debug.Log(xPos);
                float yPos = i;
                
                
                GameObject myBall = Instantiate(ball, new Vector3(xPos, yPos, 0), transform.rotation,this.transform);
                Renderer rend = myBall.GetComponent<Renderer>();
                rend.material.color = Random.ColorHSV();
            }
            rows--;
    }
        transform.position = new Vector2(offsetX,offsetY );
    }
}
