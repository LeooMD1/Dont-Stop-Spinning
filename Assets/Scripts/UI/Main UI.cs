using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class MainUI : MonoBehaviour
{
    public static float Money;
    public static float Energy = 7;
    public static float Day = 1;

    [SerializeField] private float sceneRNG;

    public Font[] fonts;
    [SerializeField] private TextMeshProUGUI energyText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI dayText;

    private void Start()
    {
        for (int i = 0; i < fonts.Length; i++)
        {
            fonts[i].material.mainTexture.filterMode = FilterMode.Point;
        }
    }

    private void Update()
    {
        energyText.text = (Mathf.RoundToInt(MainUI.Energy).ToString());
        moneyText.text = "$" + (MainUI.Money.ToString());
        dayText.text = "Day: " + (MainUI.Day.ToString());
        
        if (MainUI.Money > 0)
            moneyText.color = Color.green;
        else if (MainUI.Money < 0)
            moneyText.color = Color.red;
        else
            moneyText.color = Color.white;
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
    #endregion

    public void Sleep()
    {
        if (MainUI.Energy < 1)
        {
            //play fade animation or smth like that
            Energy = 7;
            Day += 1;

        }
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
}
