using Mono.Cecil.Cil;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class Typing : MonoBehaviour
{
    public string[] targetTextThings;
    public string targetText;
    public TextMeshProUGUI displayText;
    public TMP_InputField inputText;
    
    public string Texts;

    public int currentChar = 0;
    


    void Start()
    {
        targetText = targetTextThings[Random.Range(0, targetTextThings.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        displayText.text = targetText.Substring(0, currentChar) + "<color=grey>" + targetText.Substring(currentChar);
    }

    void OnKeyPressed()
    {
        print("bruh");
    }

    public void Test(string text)
    {
        if(text == "")return;
        
        if (text == targetText[currentChar].ToString())
        {
            print("successful type");
            currentChar++;

            if (currentChar > targetText.Length-1)
            {
                //dowtv
                print("completed");
                currentChar = 0;
                targetText = targetTextThings[Random.Range(0, targetTextThings.Length)];
            }
        }

        else if (text != targetText[currentChar].ToString())
        {
            print("cooked text");
        }



        inputText.text = "";
    }
}
