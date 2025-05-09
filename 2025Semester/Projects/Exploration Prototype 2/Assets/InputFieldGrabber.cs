using UnityEngine;
using TMPro;

public class InputFieldGrabber : MonoBehaviour
{
    [Header("A")] [SerializeField] private string inputText;

    [Header("B")] 
    [SerializeField] private GameObject reactionGroup;
    [SerializeField] private TMP_Text reactionTextBox;

    private void GrabFromInputField(string input)
    {
        inputText = input;
        DisplayReactionToInput();
    }

    private void DisplayReactionToInput()
    {
        reactionTextBox.text = "Yes?" + inputText;
        reactionGroup.SetActive(true);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
