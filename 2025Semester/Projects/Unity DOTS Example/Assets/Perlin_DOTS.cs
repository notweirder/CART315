using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using Unity.Collections;
using UnityEngine.Jobs;
using static Unity.Mathematics.math;
using Unity.Mathematics;
using Unity.Burst;

[BurstCompile]
public struct PerlinImageJob : IJobParallelFor
{
    [WriteOnly] public NativeArray<Color32> pixels;
    [ReadOnly] public int textureSize;
    [ReadOnly] public float2 noiseOffset;
    [ReadOnly] public float noiseMult;
    [ReadOnly] public float minusHalf;
    [ReadOnly] public float numOctaves, lacunarity, persistence;
    [ReadOnly] public bool vignette;
    [ReadOnly] public bool colorize;
    [ReadOnly] public NativeArray<Color32> clut;
    
    public void Execute(int ndx)
    {
        int h = ndx % textureSize;
        int v = ndx / textureSize;
        float2 loc;
        loc.x = ((minusHalf + h) * noiseMult) + noiseOffset[0];
        loc.y = ((minusHalf + v) * noiseMult) + noiseOffset[1];

        //float u = noise.cnoise(loc); //returns [-1...1, not [0...1]!
        //This loop adds octaves to the DOTS version
        float u = 0, lacu = 1, pers = 1, noiseAmt = 0;
        for (int i = 0; i < numOctaves; i++)
        {
            if (i != 0)
            {
                lacu *= lacunarity;
                pers *= persistence;
            }

            noiseAmt = noise.cnoise(loc * lacu) * pers; // returns [-1...1]*pers
            u += noiseAmt;
        }
        u = (u + 1) * 0.5f;
        //Apply the vignette after moving u to the range ~[0..1]
        if (vignette)
        {
            loc.x = h / (float)textureSize;
            loc.y = v / (float)textureSize;
            loc.x = (loc.x - 0.5f) * 3f;
            loc.y = (loc.y - 0.5f) * 3f;
            loc.x = 1 - (loc.x * loc.x);
            loc.y = 1 - (loc.y * loc.y);
            u *= (loc.x + loc.y) * 0.5f;
        }
        if (u < 0) u = 0;
        if (u > 1) u = 1;
        
        //Apply to the pixels
        byte b = (byte) (255 * u);
        if (colorize)
        {
            pixels[ndx] = clut[b];
        }
        else
        {
            pixels[ndx] = new Color32(b, b, b, 255);
        }
    }
}



[RequireComponent(typeof(MeshRenderer))]
public class Perlin_DOTS : MonoBehaviour
{
    [Header("Inscribed")] 
    public int textureSize = 1080;
    public Gradient colorGradient;
    
    [Header("Inscribed / Dynamic")] 
    public float noiseScale = 10;

    public bool regenCLUT = false;

    
    public Vector2 noiseOffset = Vector2.zero;
    public Vector2 offsetVel = new Vector2(1, 0);
    public PerlinVars perlinVars;
    public bool vignette = true;
    public bool colorize = true;
    
    private Material _mat;
    private Texture2D _tex;
    private Color32[] clut; // Color LookUp Table
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mat = GetComponent<MeshRenderer>().material;
        _tex = new Texture2D(textureSize, textureSize, TextureFormat.RGBA32, false);
        _mat.mainTexture = _tex;

        GenerateCLUT();
    }

    void GenerateCLUT()
    {
        // Generate the Color LookUp Table
        clut = new Color32[256];
        float step = 1f / 255f;
        Color32 col;
        float u = 0;
        for (int i = 0; i < 256; i++, u += step)
        {
            col = colorGradient.Evaluate(u);
            clut[i] = col;
        }

        regenCLUT = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        //Regenerate clut when regenCLUT is checked
        if (regenCLUT) GenerateCLUT();
        noiseOffset += offsetVel * Time.deltaTime;
        UpdateTex();
    }

    void UpdateTex()
    {
        //Prepare the job. including precalculating some math

        PerlinImageJob jobData = new PerlinImageJob();

        jobData.pixels = _tex.GetRawTextureData<Color32>();
        jobData.textureSize = textureSize;
        jobData.noiseOffset = noiseOffset;
        jobData.noiseMult = noiseScale / (float)textureSize;
        jobData.minusHalf = -textureSize * 0.5f;

        jobData.numOctaves = perlinVars.numOctaves;
        jobData.lacunarity = perlinVars.lacunarity;
        jobData.persistence = perlinVars.persistence;

        jobData.vignette = vignette;
        jobData.colorize = colorize;
        jobData.clut = new NativeArray<Color32>(clut, Allocator.TempJob);
        
        // Schedule the job
        JobHandle handle = jobData.Schedule(jobData.pixels.Length, 64);
        
        // Wait for the job to complete
        handle.Complete();
        
        // Clean up the jobData.clut memory allocation

        jobData.clut.Dispose();
        
        _tex.Apply(false);
    }
}
