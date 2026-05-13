using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Typing : MonoBehaviour
{
    public string[] targetTextThings;
    public string targetText;
    public TextMeshProUGUI displayText;
    public TMP_InputField inputText;
    
    public string Texts;

    [SerializeField] private float amountEarned;

    public int currentChar = 0;

    [SerializeField] private Button sendButton;
    


    void Start()
    {
        sendButton.enabled = false;
        targetText = targetTextThings[Random.Range(0, targetTextThings.Length)];

        amountEarned = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (MainUI.Energy >= 1)
            inputText.enabled = true;
        else if (MainUI.Energy < 1)
            inputText.enabled = false;
        
        displayText.text = targetText.Substring(0, currentChar) + "<color=grey>" + targetText.Substring(currentChar);
        amountEarned = Mathf.Clamp(amountEarned,0, 1000);
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
                sendButton.enabled = true;
                print("completed");
                
            }
        }

        else if (text != targetText[currentChar].ToString())
        {
            print("cooked text");
            amountEarned -= 10;
            //start shake
        }

        inputText.text = "";
    }

    public void NewEmailGenerator()
    {
        currentChar = 0;
        targetText = targetTextThings[Random.Range(0, targetTextThings.Length)];
        sendButton.enabled = false;

        MainUI.Money += amountEarned;
    }

    

    
}
