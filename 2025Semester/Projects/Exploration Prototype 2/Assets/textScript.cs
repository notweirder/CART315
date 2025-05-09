using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class textScript : MonoBehaviour
{
        public Text myText;
        public string myString = "hello";
        private string newString;   //'newString' acts as a temporary variable to set myText to (e.g. "Hel" from "Hello")
        private int count = 0;  // 'count' is for iterating through the string length 
        public float textSpeed;
        void Start()
        {
            StartCoroutine(ExampleCoroutine());
        }

        IEnumerator ExampleCoroutine()
        {
            count++;
            newString = myString.Substring(0, count);
            myText.text = newString;
            yield return new WaitForSeconds(textSpeed);
            StartCoroutine(ExampleCoroutine());

        }
        // void Update()
        // {
        //     
        //     /*
        //      * TO DO:
        //      * - TextMeshPro keyinput
        //      * - Try new paragraph indents
        //      * TO TEST:
        //      * - Two choices, choice A, choice B
        //      * If choice A, hit enter: Dipslay text A
        //      * If choice B, hit enter: Display text B
        //      * Replace text input
        //     */
        //     if (Input.anyKeyDown)
        //     {
        //         count++;
        //         newString = myString.Substring(0, count);
        //         myText.text = newString;
        //         
        //     }
        // }
    }


   

