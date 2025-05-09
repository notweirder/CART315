using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PerlinVars
{
    public int numOctaves = 4;
    public float lacunarity = 2f;
    public float persistence = 0.5f;
}
[RequireComponent(typeof(MeshRenderer))] //ensures MeshRenderer is attached to GameObject
public class Perlin_OOP : MonoBehaviour
{
    [Header("Inscribed")]
    public int textureSize = 1080;

    [Header("Inscribed / Dynamic")] 
    
    public float noiseScale = 10;
    public Vector2 noiseOffset = Vector2.zero;
    public Vector2 offsetVel = new Vector2(1, 0);
    public PerlinVars perlinVars;
    
    private Material _mat;
    private Texture2D _tex;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mat = GetComponent<MeshRenderer>().material;

        InitTex();
        _mat.mainTexture = _tex;
    }

    void InitTex()
    {
        _tex = new Texture2D(textureSize, textureSize, TextureFormat.RGBA32, false);
        UpdateTex();
    }
    // Update is called once per frame
    void Update()
    {
        noiseOffset += offsetVel * Time.deltaTime;
        UpdateTex();
    }

    void UpdateTex()
    {
        //Generate the array to fill
        Color[] pixels = new Color[textureSize * textureSize];
        
        //Precalculate some math
        float noiseMult = noiseScale / (float)textureSize;
        int ndx = 0;
        float x, y, u;
        float minusHalf = -textureSize * 0.5f;
        for (int v = 0; v < textureSize; v++)
        {
            for (int h = 0; h < textureSize; h++, ndx++)
            {
                x = ((minusHalf + h) * noiseMult) + noiseOffset.x;
                y = ((minusHalf + v) * noiseMult) + noiseOffset.y;

                //u = Mathf.PerlinNoise(x, y);
                u = PerlinOctaves(perlinVars, x, y);
                pixels[ndx] = new Color(u, u, u, 1);
            }
        }
        
        _tex.SetPixels(pixels);
        _tex.Apply(false);
    }

    public float PerlinOctaves(PerlinVars pVars, float x, float y)
    {
        float u = 0, lacu = 1, pers = 1, noiseAmt;
        for (int octave = 0; octave < pVars.numOctaves; octave++)
        {
            //lacu = Mathf.Pow(pVars.lacunarity,o);
            //pers = Mathf.Pow(pVars.persistence, o);
            if (octave != 0)
            {
                lacu *= pVars.lacunarity;
                pers *= pVars.persistence;
            }

            noiseAmt = (Mathf.PerlinNoise(x * lacu, y * lacu) - 0.5f) * pers;
            u += noiseAmt;
        }

        return u + 0.5f;
    }
}
