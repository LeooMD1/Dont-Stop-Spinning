
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
    [SerializeField] private float energyUsed;

    public int currentChar = 0;

    [SerializeField] private Button sendButton;
    [SerializeField] private Image sendImage;
    [SerializeField] private Shake shake;

    [SerializeField] private GameObject Carat;
    
    [SerializeField] private TextMeshProUGUI amountText;
    [SerializeField] private TextMeshProUGUI energyText;
    
    [SerializeField] private AudioManager audioManager;

    [SerializeField] private float timer = 30;
    [SerializeField] private float timerCooldown = 30;
    [SerializeField] private float timeMoneyDeduct;
    
    [SerializeField] private TextMeshProUGUI timerText;

    


    void Start()
    {
        sendButton.enabled = false;
        targetText = targetTextThings[Random.Range(0, targetTextThings.Length)];

        amountEarned = 200;
        energyUsed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (MainUI.Energy > 0)
            inputText.enabled = true;
        else if (MainUI.Energy < 1)
            inputText.enabled = false;

        if (inputText.isFocused)
            Carat.SetActive(true);
        else
            Carat.SetActive(false);

        if (timer <= 0.5)
        {
            amountEarned -= timeMoneyDeduct;
            timer = timerCooldown;
            StartCoroutine(shake.Shaking());
        }
        
        timer -= Time.deltaTime;
        
        displayText.text = targetText.Substring(0, currentChar) + "<color=grey>" + targetText.Substring(currentChar);
        amountEarned = Mathf.Clamp(amountEarned,0, 1000);

        amountText.text = "+$" + amountEarned.ToString();
        energyText.text = "-" + energyUsed.ToString();
        timerText.text = Mathf.RoundToInt(timer).ToString() + "s"; 

        var currentCharInfo = displayText.textInfo.characterInfo[currentChar];
        Debug.DrawLine(displayText.transform.TransformPoint(currentCharInfo.topLeft), displayText.transform.TransformPoint(currentCharInfo.bottomLeft), Color.red);
        Carat.transform.position = (displayText.transform.TransformPoint(currentCharInfo.bottomLeft));

    }

    public void Test(string text)
    {
        if(text == "")return;
        
        if (text == targetText[currentChar].ToString())
        {
            audioManager.PlaySFX(audioManager.Keyboard);
            print("successful type");
            currentChar++;

            if (currentChar > targetText.Length-1)
            {
                sendButton.enabled = true;
                Carat.SetActive(false);
                print("completed");
                sendImage.color = Color.green;
                


            }

            else
            {
                Carat.SetActive(true);
                sendImage.color = Color.white;

            }
        }

        else if (text != targetText[currentChar].ToString())
        {
            print("cooked text");
            amountEarned -= 10;
            //start shake
            StartCoroutine(shake.Shaking());
            
        }

        inputText.text = "";
    }
    
    public void NewEmailGenerator()
    {
        sendImage.color = Color.white;
        currentChar = 0;
        targetText = targetTextThings[Random.Range(0, targetTextThings.Length)];
        MainUI.Money += amountEarned;
        MainUI.Energy -= energyUsed;
        
        sendButton.enabled = false;
        amountEarned = 200;

    }

    

    
}
