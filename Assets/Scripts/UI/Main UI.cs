using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MainUI : MonoBehaviour
{
    public static float Money = 35;
    public static float Energy = 7;
    public static float Day = 1;
    public static float Debt = 0;

    public static bool debtPayed;

    public bool sharkAppeared = false;
    public static bool canHide = true;

    public static bool debt1Payed = false;
    public static bool debt2Payed = false;
    public static bool debt3Payed = false;
    public static bool debt4Payed = false;
    public static bool debt5Payed = false;

    public static bool Item1Bought;
    public static bool Item2Bought;
    public static bool Item3Bought;
    public static bool ChamarBought;

    public float investChance;

    public float pay;
    
    public AdDrag adDrag;

    [SerializeField] private float sceneRNG;
    [SerializeField] private Animator sleepAnim;
    
    [SerializeField] private GameObject button;
    
    [SerializeField] private AudioManager audioManager;

    public Font[] fonts;
    [SerializeField] private TextMeshProUGUI energyText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI debtText;
    [SerializeField] private TextMeshProUGUI dayText;
    
    [SerializeField] private TextMeshProUGUI payText;
    
    [SerializeField] private Row rows;
    
    [SerializeField] private GameObject Stock;
    
    [SerializeField] private GameObject Map;
    
    [SerializeField] private GameObject Shark;
    
    [SerializeField] private Button Bank;
    [SerializeField] private Animator endAnim;
    
    [SerializeField] private TextMeshProUGUI Message;
    [SerializeField] private string messageString;
    
    
    [SerializeField] private Shake shake;
    [SerializeField] private Image Hide;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        investChance = Random.Range(0, 2);
    }

    

    private void Start()
    {


        for (int i = 0; i < fonts.Length; i++)
        {
            fonts[i].material.mainTexture.filterMode = FilterMode.Point;
        }
        button.SetActive(true);
        Stock.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioManager.PlaySFX(audioManager.ClickDown);
        }

        else if (Input.GetMouseButtonUp(0))
        {
            audioManager.PlaySFX(audioManager.ClickUp);
        }

        moneyText.text = "$" + (Mathf.Round(MainUI.Money).ToString());
        
        
        if (MainUI.Money > 0)
            moneyText.color = Color.green;
        else if (MainUI.Money < 0)
            moneyText.color = Color.red;
        else
            moneyText.color = Color.white;
        
        energyText.text = (Mathf.RoundToInt(MainUI.Energy).ToString());

        if (MainUI.Energy < 0)
            energyText.color = Color.red;
        else if (MainUI.Energy > 0)
            energyText.color = Color.yellow;
        
        debtText.text = "-$" + (Mathf.RoundToInt(MainUI.Debt).ToString());
        
        if (MainUI.Debt == 0)
            debtText.enabled = false;
        else
            debtText.enabled = true;
        
        dayText.text = "Day: " + (MainUI.Day.ToString());

        pay = Mathf.Clamp(pay, 0, 500);
        Debt = Mathf.Clamp(Debt, 0, 500);
        payText.text = "$" + (Mathf.Round(pay).ToString());

        if (Debt == 0)
            debtPayed = true;
        else
            debtPayed = false;

        if (debtPayed)
            Map.SetActive(true);

        if (Day == 21)
            Map.SetActive(false);
    }

    #region Scene loaders

    //if Not in casino
    public void CasinoLoad()
    {
        print("casinooo");
        SceneManager.LoadScene("CasinoArea");
    }

    //if In Casino
    public void SlotMachineLoad()
    {
        SceneManager.LoadScene("SlotMachine");
    }

    public void WorkLoad()
    {
        print("workkk");
        SceneManager.LoadScene("JobArea");
    }

    //choose if the player is going to do an in person job or an online job
    //as of now I am gong to make it random but this can change in the future if needed 
    public void JobChooser()
    {
        sceneRNG = Random.Range(0, 50);

        if (sceneRNG >= 25f)
            SceneManager.LoadScene("InPersonJob");
        else
            SceneManager.LoadScene("OnlineJob");
    }

    public void JobPick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void InPersonJob()
    {
        SceneManager.LoadScene("InPersonJob");
    }

    public void OnlineJob()
    {
        SceneManager.LoadScene("OnlineJob");
    }

    public void HomeLoad()
    {
        print("Homeee"); 
        SceneManager.LoadScene("HomeArea");
    }

    public void ShopLoad()
    {
        SceneManager.LoadScene("Shop");
    }
    #endregion

    public void ComputerClickDialogue()
    {
        if (MainUI.Day == 1)
        {
            messageString = "Thanks for coming to me, you've made the BEST decision... However, you do need to repay me so maybe try to look for a job or... <color=red> gamble </color=black> for the deal I am offering. I will provide more detail tommorow.";
            Message.text = messageString;
        }

        else if (MainUI.Day == 2)
        {
            messageString = "As I said in the previous message, you will need to start paying me back. You can pay me using <color=green> Buoy Bank </color=black>. I want <color=green> $100 </color=black> in 1 day. I WILL get my payment one way or another :)";
            Message.text = messageString;
            Debt = 100;
        }
        
        else if (MainUI.Day == 3)
        {
            messageString = "Payment dayyyyy. Pay me <color=#53bfed> pleasee </color=black>";
            Message.text = messageString;
        }

        else if (MainUI.Day == 4 && debtPayed)
        {
            messageString = "Thank you for the payment, I always knew you would be one of my best customers. Next payment is in 3 days, I will provide you with the amount tomorrow. I believe you can pay on time.";
            Message.text = messageString;
            debt1Payed = true;
            
        }

        else if (MainUI.Day == 4 && !debtPayed)
        {
            messageString = "You did not pay me. I will collect my money. I know where you are and I will show up.";
            Message.text = messageString;
            
            sharkAppeared = true;
            if(!debtPayed)
                SpawnShark();
            //start coroutine or function of loan shark spawning in and taking money
            //allow player to chose to hide (one time use) using static bool and no money will be taken or give them option to pay extra
        }

        else if (MainUI.Day == 5)
        {
            messageString = "For your next payment, I will be expecting <color=green> $250 </color=black> in the next 2 days.";
            Message.text = messageString;
            Debt = 250;
        }
        
        else if (MainUI.Day == 6)
        {
            messageString = "1 day.";
            Message.text = messageString;
        }
        
        else if (MainUI.Day == 7 && debt1Payed)
        {
            messageString = "You know what day it is, You're' one of the best customers I have ever had. I know you would never miss a deadline as that would be... bad. Anyways I may or may not be in contact with you tomorrow ;)";
            Message.text = messageString;
            debt2Payed = true;
        }
        
        else if (MainUI.Day == 7 && !debt1Payed)
        {
            messageString = "Pay me. Don't make the same mistake you made last time. My patience is running thin and I could take more then just money from you... <color=#660000>Send. Me. My. Money..</color=black>";
            Message.text = messageString;
        }

        else if (MainUI.Day == 8 && debtPayed && debt1Payed)
        {
            messageString = "I love how quick you catch onto things, I don't think we will have any <color=#660000> problems.. </color=black> I shall be in contact with you in 2 days discussing the next payment. Thank you.";
            Message.text = messageString;
        }
        
        else if (MainUI.Day == 8 && debtPayed && !debt1Payed)
        {
            messageString = "I'm glad you caught onto how things work around here.<color=#660000> Do not make that mistake again </color=black>. I will contact you again in 2 days about the following payment";
            Message.text = messageString;
        }

        else if (MainUI.Day == 8 && !debtPayed && !debt1Payed)
        {
            messageString = "You don't seem to understand how things work around here. <color=#660000> Do I need to teach you </color=black>? ";
            Message.text = messageString;

            sharkAppeared = true;
            if (!debtPayed)
                SpawnShark();
            //start coroutine or function of loan shark spawning in and taking money
            //allow player to chose to hide (one time use) using static bool and no money will be taken or give them option to pay extra
        }

        else if (MainUI.Day == 9)
        {
            messageString = "No New Messages...";
            Message.text = messageString;
        }
        
        else if (MainUI.Day == 10)
        {
            messageString = "You are still in debt to me, I've got you off the hook of your rent, I payed that rent off for you. It would be very, VERY unfair if you didn't need to pay me back. I want <color=green> $500 </color=black> 5 days.";
            Message.text = messageString;
        }
        
        else if (MainUI.Day == 11)
        {
            messageString = "No New Messages...";
            Message.text = messageString;
        }
        
        else if (MainUI.Day == 12)
        {
            messageString = "No New Messages...";
            Message.text = messageString;
        }
        
        else if (MainUI.Day == 13)
        {
            messageString = "2 More Days. I am expecting my money.";
            Message.text = messageString;
        }
        
        else if (MainUI.Day == 14)
        {
            messageString = "1 More Day.";
            Message.text = messageString;
        }
        
        else if (MainUI.Day == 15)
        {
            messageString = "Pay day is today. You need to pay me.";
            Message.text = messageString;
        }
        
        else if (MainUI.Day == 16 && debtPayed)
        {
            messageString = "I need <color=green> $1000</color=black> in the next 4 days. I don't care how you get this money but I need it one way or another.";
            Message.text = messageString;
        }
        
        else if (MainUI.Day == 16 && !debtPayed)
        {
            messageString = "I get my money eventually... <color=#660000> Trust me </color=black>.";
            Message.text = messageString;

            sharkAppeared = true;
            if (!debtPayed)
                SpawnShark();
            //start coroutine or function of loan shark spawning in and taking money
            //allow player to chose to hide (one time use) using static bool and no money will be taken or give them option to pay extra
        }
        
        else if (MainUI.Day == 17)
        {
            messageString = "<color=green> $1000 </color=black>. 3 More Days. Hurry up otherwise it won't just be you facing the consequences";

            Debt = 1000;
            Message.text = messageString;
        }
        
        else if (MainUI.Day == 18)
        {
            messageString = "No New Messages...";
            Message.text = messageString;
        }
        
        else if (MainUI.Day == 19)
        {
            messageString = "1 Day.";
            Message.text = messageString;
        }
        
        else if (MainUI.Day == 20)
        {
            messageString = "Send it. I don't have all day.";
            Message.text = messageString;
        }
        
        else if (MainUI.Day == 21 && debtPayed)
        {
            messageString = "I will leave you for now... but I WILL be back. You came to me, I will be here until you pay every. last. penny.";
            Message.text = messageString;

            StartCoroutine(GoodEnding());

            //goodish ending not really but a ending
        }               
        
        else if (MainUI.Day == 21 && !debtPayed)
        {
            messageString = "People like you disgust me. You leech off of others like a helpless dog. <color=#660000> You are pathetic </color=black>. You won't escape me until I have every single penny that I lent you back..";
            Message.text = messageString;

            sharkAppeared = true;
            if (!debtPayed)
                SpawnShark();

            StartCoroutine(BadEnding());
        }

    }

    private IEnumerator GoodEnding()
    {
        yield return new WaitForSeconds(5);
        endAnim.SetTrigger("Start");
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene("Good Ending");
    }
    private IEnumerator BadEnding()
    {
        yield return new WaitForSeconds(7);
        endAnim.SetTrigger("Start");
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene("Bad Ending");
    }
    
    public void PayShark()
    {
        if (debtText.enabled)
        {
            if (Money >= pay)
            {
                Money -= pay;
                Debt -= pay;

            }
        }
    }

    public void SpawnShark()
    {
        if (sharkAppeared)
        {
            Bank.enabled = false;
            Shark.SetActive(true);
        }
        
        else if (!sharkAppeared)
        {
            Bank.enabled = true;
            Shark.SetActive(false); 
        }
    }

    public void PayButtonForShark()
    {
        Money -= Debt * 1.2f;
        Shark.SetActive(false); 
        Map.SetActive(true);

        Debt = 0;
    }

    public void HideButtonForShark()
    {
        if (canHide)
        {
            Hide.enabled = true;
            Shark.SetActive(false);
            canHide = false;
            Map.SetActive(true);
            Debt = 0;
        }

        else if (!canHide)
        {
            Hide.enabled = false;
            StartCoroutine(shake.Shaking());
        }
    }
    
    public void Sleep()
    {
        if (MainUI.Energy < 1)
        {
            StartCoroutine(Sleeping());                     
        }

        //debt amounts set whenever player goes to sleep else debts can be completely avoided
    }

    private IEnumerator Sleeping()
    {
        button.SetActive(false);
        sleepAnim.SetTrigger("Sleep");
        yield return new WaitForSeconds(1f);
        Energy = 7;
        Day += 1;
        button.SetActive(true);
        #region Debt amounts
        if (Day == 2)
            Debt = 100;

        else if (Day == 5)
            Debt = 250;
        else if (Day == 10)
            Debt = 500;
        #endregion
        #region Shark Days
        if (Day == 4 && !debtPayed)
            Map.SetActive(false);        

        else if (Day == 8 && !debtPayed)
            Map.SetActive(false);

        else if (Day == 16 && !debtPayed)
            Map.SetActive(false);

        #endregion
    }

    public void Buys()
    {
        if (adDrag.invest && MainUI.Energy >= 1 && MainUI.Money >= 1)
        {
            adDrag.prizeValue = 25;
            adDrag.prizeReward.color = Color.green;
            adDrag.energyUsed = -1;
            Stock.SetActive(false);

        }

        else if (!adDrag.invest && MainUI.Energy >= 1 && MainUI.Money >= 1)
        {
            adDrag.prizeValue = -25;
            adDrag.prizeReward.color = Color.red;
            adDrag.energyUsed = -1;
            Stock.SetActive(false);
        }

        StartCoroutine(TextDisplay());
    }

    public void Sells()
    {
        if (!adDrag.invest && MainUI.Energy >= 1 && MainUI.Money >= 1)
        {
            adDrag.prizeValue = 25;
            adDrag.prizeReward.color = Color.green;
            adDrag.energyUsed = -1;
            Stock.SetActive(false);
        }

        else if (adDrag.invest && MainUI.Energy >= 1 && MainUI.Money >= 1)
        {
            adDrag.prizeValue = -25;
            adDrag.prizeReward.color = Color.red;
            adDrag.energyUsed = -1;
            Stock.SetActive(false);
        }

        StartCoroutine(TextDisplay());
    }

    private IEnumerator TextDisplay()
    {
        adDrag.prizeReward.text = "+$" + (adDrag.prizeValue.ToString());
        adDrag.prizeReward.enabled = true;

        adDrag.energyDisplay.text = adDrag.energyUsed.ToString();
        adDrag.energyDisplay.enabled = true;

        yield return new WaitForSeconds(0.5f);

        //audioManager.PlaySFX(audioManager.stock);
        MainUI.Money += adDrag.prizeValue;
        adDrag.prizeReward.enabled = false;

        MainUI.Energy += adDrag.energyUsed;
        adDrag.energyDisplay.enabled = false;
    }

    #region Money Things

    public void IncreaseMoney(float amt)
    {
        pay += amt;
    }

    public void DecreaseMoney(float amt)
    {
        pay -= amt;
    }

    #endregion

    #region Audio Stuff

    public void SpinSound()
    {
        if (rows.canSpin && MainUI.Energy >= 1 && rows.hasMoney)
            audioManager.PlaySFX(audioManager.lever);

    }

    #endregion
}
