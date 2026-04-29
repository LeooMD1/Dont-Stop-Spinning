using System.Collections;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
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
    
    public static bool  Debt1Payed;
    public static bool  Debt2Payed;
    public static bool  Debt3Payed;
    public static bool  Debt4Payed;
    public static bool  Debt5Payed;

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
    
    [SerializeField] private TextMeshProUGUI Message;
    [SerializeField] private string messageString;

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
        moneyText.text = "$" + (MainUI.Money.ToString());
        
        if (MainUI.Money > 0)
            moneyText.color = Color.green;
        else if (MainUI.Money < 0)
            moneyText.color = Color.red;
        else
            moneyText.color = Color.white;
        
        energyText.text = (Mathf.RoundToInt(MainUI.Energy).ToString());
        
        if (MainUI.Debt == 0)
            debtText.enabled = false;
        else
            debtText.enabled = true;
        
        dayText.text = "Day: " + (MainUI.Day.ToString());
        debtText.text = "-$" + (Mathf.RoundToInt(MainUI.Debt).ToString());

        pay = Mathf.Clamp(pay, 0, 500);
        payText.text = "$" + (Mathf.Round(pay).ToString());
        


        if (MainUI.Day == 1)
        {
            messageString = "Thanks for coming to me, you've made the BEST decision... However, you do need to repay me so maybe try to look for a job or... <color=red> gamble </color=black> for the deal I am offering. I will provide more detail tommorow.";
            Message.text = messageString;
        }

        else if (MainUI.Day == 2)
        {
            messageString = "As I said in the previous message, you will need to start paying me back. You can pay me using <color=green> Bouy Bank </color=black>. I want <color=green> $100 </color=black> in 1 day. I WILL get my payment one way or another :)";
            Message.text = messageString;
            Debt = 100;
        }
        
        else if (MainUI.Day == 3)
        {
            messageString = "Payment dayyyyy. Pay me <color=#53bfed> pleasee </colour=black>";
            Message.text = messageString;
        }

        else if (MainUI.Day == 4 && Debt1Payed)
        {
            messageString = "Thank you for the payment, I always knew you would be one of my best customers. Next payment is in 3 days, I need <color=green> $250 </colour=black>. I believe you can pay on time.";
            Message.text = messageString;
            Debt = 250;
        }

        else if (MainUI.Day == 4 && !Debt1Payed)
        {
            messageString = "You did not pay me. I will collect my money. I know where you are and I will show up.";
            Message.text = messageString;
            //start coroutine or function of loan shark spawning in and taking money
        }

        else if (MainUI.Day == 5)
        {
            messageString = "2 days.";
            Message.text = messageString;
        }
        
        else if (MainUI.Day == 5)
        {
            messageString = "2 days.";
            Message.text = messageString;
        }

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

    public void Sleep()
    {
        if (MainUI.Energy < 1)
        {
            StartCoroutine(Sleeping());                     
        }
    }

    private IEnumerator Sleeping()
    {
        button.SetActive(false);
        sleepAnim.SetTrigger("Sleep");
        yield return new WaitForSeconds(1f);
        Energy = 7;
        Day += 1;
        button.SetActive(true);
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
