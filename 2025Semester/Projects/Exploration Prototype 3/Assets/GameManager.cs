using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager S;

    public int score;
    
    public string[] pool =
    {
        "Swimming pool",
        "Swimming pool",
        "Objects pooling together",
        "Pool game",
        "Putting money together",
        "Carpooling",
        "Rich people",
        "Changing seasons",
        "Filling with different liquids",
        "Scrooge McDuck swimming in money",
        "Pool balls",
        "Poodle?",
        "Poo? (No)",
        "Water",
        "Chlorine",
        "Floaties",
        "Lifeguards",
        "Lazy rivers"
    };


    public string[] cleaning =
    {
        "Reverse splatoon",
        "Swiffer",
        "Moving objects away",
        "Unpacking (video game)",
        "OCD",
        "Marie Kondo",
        "Removing digital artifacts",
        "At ease",
        "Physical effort",
        "Mom",
        "Sorting items",
        "Uncovering objects",
        "Gloves",
        "Smell (good and bad)",
        "Washing machine",
        "Dishwasher",
        "Soap"
    };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (S == null) S = this;
        else Destroy(gameObject);
        score = 0;
    }

    private void Start()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            for (int j = 0; j < cleaning.Length; j++)
            {
                System.Console.WriteLine(pool[i] + " + " + cleaning[j]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
