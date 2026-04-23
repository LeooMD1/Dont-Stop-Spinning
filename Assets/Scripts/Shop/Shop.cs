using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;

    public GameObject Info1;
    public GameObject Info2;
    public GameObject Info3;

    public bool bought = false;
    private float prizeValue;

    [SerializeField] private TextMeshProUGUI prizeReward;

    void Start()
    {
        if (MainUI.Item1Bought)
            Item1.SetActive(false);
        
        if (MainUI.Item2Bought)
            Item2.SetActive(false);

        if (MainUI.Item3Bought)
            Item3.SetActive(false);
        
        
        Info1.SetActive(false);       
        Info2.SetActive(false);
        Info3.SetActive(false);

        prizeReward.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ItemPressed(GameObject info)
    {
        if (!info.activeInHierarchy)
        {
            info.SetActive(true);
        }

        else if (info.activeInHierarchy)
        {
            info.SetActive(false);
        }
    }
    
    
    public void Buy(float cost)
    {
        if (MainUI.Money > cost)
        {
            prizeValue = cost;
            bought = true;
            StartCoroutine(CostDeduct());
        }
    }

    private IEnumerator CostDeduct()
    {
        prizeReward.text = "-$" + (prizeValue.ToString());
        prizeReward.enabled = true;

        yield return new WaitForSeconds(1);

        MainUI.Money -= prizeValue;
        bought = false;
        prizeReward.enabled = false;
        //audioManager.PlaySFX(audioManager.money);

    }

    public void Item1Bought()
    {
        if (bought)
        {
            Item1.SetActive(false);
            Info1.SetActive(false);
            MainUI.Item1Bought = true;
            print(MainUI.Item1Bought);
        }
    }

    public void Item2Bought()
    {
        if (bought)
        {
            Item2.SetActive(false);
            Info2.SetActive(false);
            MainUI.Item2Bought = true;
            print(MainUI.Item2Bought);
        }
    }

    public void Item3Bought()
    {
        if (bought)
        {
            Item3.SetActive(false);
            Info3.SetActive(false);
            MainUI.Item3Bought = true;
            print(MainUI.Item3Bought);
        }
    }
}
