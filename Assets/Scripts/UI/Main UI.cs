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

    public static bool Item1Bought;
    public static bool Item2Bought;
    public static bool Item3Bought;

    public float investChance;
    public AdDrag adDrag;

    [SerializeField] private float sceneRNG;
    [SerializeField] private Animator sleepAnim;
    
    [SerializeField] private GameObject button;
    
    [SerializeField] private AudioManager audioManager;

    public Font[] fonts;
    [SerializeField] private TextMeshProUGUI energyText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI dayText;
    
    [SerializeField] private Row rows;
    
    [SerializeField] private GameObject Stock;

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
        dayText.text = "Day: " + (MainUI.Day.ToString());

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
        Money += amt;
    }

    public void DecreaseMoney(float amt)
    {
        Money -= amt;
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
