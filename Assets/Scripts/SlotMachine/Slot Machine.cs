using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements.Experimental;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    #region Variables and stuff
    public static event Action ButtonPressed = delegate { };

    [SerializeField]
    private TextMeshProUGUI prizeText;
    [SerializeField] private GameObject Leave;
    [SerializeField] private Button button;

    [SerializeField]
    private Row[] rows;

    [SerializeField] AudioManager audioManager;
    [SerializeField] TextMeshProUGUI cost;

    public float prizeValue;

    public bool resultsChecked = false;
    public bool fiveInARow = false;
    #endregion

    private void Start()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        if (MainUI.Money < rows[0].newAmountText)
        {
            button.interactable = false;
        }

        else if (MainUI.Energy < 1)
        {
            button.interactable = false;
        }

        else if (!rows[0].canSpin)
        {
            button.interactable = false;
        }

        else
            button.interactable = true;

        cost.text = rows[0].newAmountText.ToString();
        
        if (!rows[0].canSpin && !rows[1].canSpin && !rows[2].canSpin && !rows[3].canSpin && !rows[4].canSpin && resultsChecked)
        {
            prizeValue = 0;
            prizeText.enabled = false;
            resultsChecked = false;
            fiveInARow = false;
            Leave.SetActive(false);
        }

        if (rows[0].canSpin && rows[1].canSpin && rows[2].canSpin && rows[3].canSpin && rows[4].canSpin && !resultsChecked)
        {
            CheckResults();
            prizeText.enabled = true;
            Leave.SetActive(true);
        }
        
        prizeText.text = "$" + (prizeValue.ToString());
        

        if (prizeValue < 0)
            prizeText.color = Color.red;
        else if (prizeValue > 0)
            prizeText.color = Color.green;
        else
            prizeText.color = Color.gray;
    }

    private void CheckResults()
    {
        #region 5-Row Pattern
        if (rows[0].targetItem == "Cherry"
            && rows[1].targetItem == "Cherry"
            && rows[2].targetItem == "Cherry"
            && rows[3].targetItem == "Cherry"
            && rows[4].targetItem == "Cherry" && !MainUI.Item3Bought)
        {
            prizeValue = 500;

            fiveInARow = true;
        }
        
        else if (rows[0].targetItem == "Cherry"
            && rows[1].targetItem == "Cherry"
            && rows[2].targetItem == "Cherry"
            && rows[3].targetItem == "Cherry"
            && rows[4].targetItem == "Cherry" && MainUI.Item3Bought)
        {
            prizeValue = 300;

            fiveInARow = true;
        }


        else if (rows[0].targetItem == "Banana"
            && rows[1].targetItem == "Banana"
            && rows[2].targetItem == "Banana"
            && rows[3].targetItem == "Banana"
            && rows[4].targetItem == "Banana" && !MainUI.Item3Bought)
        {


            prizeValue = 250;
            fiveInARow = true;
        }
        
        else if (rows[0].targetItem == "Banana"
            && rows[1].targetItem == "Banana"
            && rows[2].targetItem == "Banana"
            && rows[3].targetItem == "Banana"
            && rows[4].targetItem == "Banana" && MainUI.Item3Bought)
        {
            prizeValue = 100;
            fiveInARow = true;
        }

        else if (rows[0].targetItem == "Kiwi"
            && rows[1].targetItem == "Kiwi"
            && rows[2].targetItem == "Kiwi"
            && rows[3].targetItem == "Kiwi"
            && rows[4].targetItem == "Kiwi" && !MainUI.Item3Bought)
        {
            prizeValue = 800;
            fiveInARow = true;
        }
        
        else if (rows[0].targetItem == "Kiwi"
            && rows[1].targetItem == "Kiwi"
            && rows[2].targetItem == "Kiwi"
            && rows[3].targetItem == "Kiwi"
            && rows[4].targetItem == "Kiwi" && MainUI.Item3Bought)
        {
            prizeValue = 500;
            fiveInARow = true;
        }

        else if (rows[0].targetItem == "Orange"
            && rows[1].targetItem == "Orange"
            && rows[2].targetItem == "Orange"
            && rows[3].targetItem == "Orange"
            && rows[4].targetItem == "Orange" && !MainUI.Item3Bought)
        {


            prizeValue = 100;
            fiveInARow = true;
        } 
        
        else if (rows[0].targetItem == "Orange"
            && rows[1].targetItem == "Orange"
            && rows[2].targetItem == "Orange"
            && rows[3].targetItem == "Orange"
            && rows[4].targetItem == "Orange" && MainUI.Item3Bought)
        {


            prizeValue = 20;
            fiveInARow = true;
        }

        else if (rows[0].targetItem == "Grape"
            && rows[1].targetItem == "Grape"
            && rows[2].targetItem == "Grape"
            && rows[3].targetItem == "Grape"
            && rows[4].targetItem == "Grape" && !MainUI.Item3Bought)
        {


            prizeValue = 75;
            fiveInARow = true;
        }
        
        else if (rows[0].targetItem == "Grape"
            && rows[1].targetItem == "Grape"
            && rows[2].targetItem == "Grape"
            && rows[3].targetItem == "Grape"
            && rows[4].targetItem == "Grape" && MainUI.Item3Bought)
        {


            prizeValue = 15;
            fiveInARow = true;
        }

        else if (rows[0].targetItem == "Mango"
            && rows[1].targetItem == "Mango"
            && rows[2].targetItem == "Mango"
            && rows[3].targetItem == "Mango"
            && rows[4].targetItem == "Mango" && !MainUI.Item3Bought)
        {


            prizeValue = 400;
            fiveInARow = true;
        } 
        
        else if (rows[0].targetItem == "Mango"
            && rows[1].targetItem == "Mango"
            && rows[2].targetItem == "Mango"
            && rows[3].targetItem == "Mango"
            && rows[4].targetItem == "Mango" && MainUI.Item3Bought)
        {


            prizeValue = 250;
            fiveInARow = true;
        }

        else if (rows[0].targetItem == "7"
            && rows[1].targetItem == "7"
            && rows[2].targetItem == "7"
            && rows[3].targetItem == "7"
            && rows[4].targetItem == "7" && !MainUI.Item3Bought)
        {


            prizeValue = 1500;
            fiveInARow = true;
        } 
        
        else if (rows[0].targetItem == "7"
            && rows[1].targetItem == "7"
            && rows[2].targetItem == "7"
            && rows[3].targetItem == "7"
            && rows[4].targetItem == "7" && MainUI.Item3Bought)
        {


            prizeValue = 750;
            fiveInARow = true;
        }

        else if (rows[0].targetItem == "6"
            && rows[1].targetItem == "6"
            && rows[2].targetItem == "6"
            && rows[3].targetItem == "6"
            && rows[4].targetItem == "6" && MainUI.Item2Bought)

            prizeValue = -1800; 
        
        else if (rows[0].targetItem == "6"
            && rows[1].targetItem == "6"
            && rows[2].targetItem == "6"
            && rows[3].targetItem == "6"
            && rows[4].targetItem == "6" && MainUI.Item3Bought)

            prizeValue = -1000;

        else if (rows[0].targetItem == "6"
            && rows[1].targetItem == "6"
            && rows[2].targetItem == "6"
            && rows[3].targetItem == "6"
            && rows[4].targetItem == "6" && !MainUI.Item3Bought)

            prizeValue = -1750;


        #endregion

        #region 3-Row Pattern
        else if (
            (rows[0].targetItem == "Cherry") &&
            (rows[2].targetItem == "Cherry") &&
            (rows[4].targetItem == "Cherry") && !MainUI.Item3Bought)

            prizeValue = 250;
        
        else if (
            (rows[0].targetItem == "Cherry") &&
            (rows[2].targetItem == "Cherry") &&
            (rows[4].targetItem == "Cherry") && MainUI.Item3Bought)

            prizeValue = 50;

        else if (
            (rows[0].targetItem == "Banana") &&
            (rows[2].targetItem == "Banana") &&
            (rows[4].targetItem == "Banana") && !MainUI.Item3Bought)

            prizeValue = 50; 
        
        else if (
            (rows[0].targetItem == "Banana") &&
            (rows[2].targetItem == "Banana") &&
            (rows[4].targetItem == "Banana") && MainUI.Item3Bought)

            prizeValue = 5;

        else if (
            (rows[0].targetItem == "Kiwi") &&
            (rows[2].targetItem == "Kiwi") &&
            (rows[4].targetItem == "Kiwi") && !MainUI.Item3Bought)

            prizeValue = 400; 
        
        else if (
            (rows[0].targetItem == "Kiwi") &&
            (rows[2].targetItem == "Kiwi") &&
            (rows[4].targetItem == "Kiwi") && MainUI.Item3Bought)

            prizeValue = 100;

        else if (
            (rows[0].targetItem == "Orange") &&
            (rows[2].targetItem == "Orange") &&
            (rows[4].targetItem == "Orange") && !MainUI.Item3Bought)

            prizeValue = 50;
        
        else if (
            (rows[0].targetItem == "Orange") &&
            (rows[2].targetItem == "Orange") &&
            (rows[4].targetItem == "Orange") && MainUI.Item3Bought)

            prizeValue = 15;

        else if (
            (rows[0].targetItem == "Grape") &&
            (rows[2].targetItem == "Grape") &&
            (rows[4].targetItem == "Grape") && !MainUI.Item3Bought)

            prizeValue = 50;
        
        else if (
            (rows[0].targetItem == "Grape") &&
            (rows[2].targetItem == "Grape") &&
            (rows[4].targetItem == "Grape") && MainUI.Item3Bought)

            prizeValue = 20;

        else if (
            (rows[0].targetItem == "Mango") &&
            (rows[2].targetItem == "Mango") &&
            (rows[4].targetItem == "Mango") && !MainUI.Item3Bought)

            prizeValue = 200; 
        
        else if (
            (rows[0].targetItem == "Mango") &&
            (rows[2].targetItem == "Mango") &&
            (rows[4].targetItem == "Mango") && MainUI.Item3Bought)

            prizeValue = 100;

        else if (
            (rows[0].targetItem == "7") &&
            (rows[2].targetItem == "7") &&
            (rows[4].targetItem == "7") && !MainUI.Item3Bought)

            prizeValue = 750;
        
        else if (
            (rows[0].targetItem == "7") &&
            (rows[2].targetItem == "7") &&
            (rows[4].targetItem == "7") && MainUI.Item3Bought)

            prizeValue = 300;

        else if (
            (rows[0].targetItem == "6") &&
            (rows[2].targetItem == "6") &&
            (rows[4].targetItem == "6") && MainUI.Item2Bought)

            prizeValue = -850;
         
        else if (
            (rows[0].targetItem == "6") &&
            (rows[2].targetItem == "6") &&
            (rows[4].targetItem == "6") && MainUI.Item3Bought)

            prizeValue = -500;

        else if (
            (rows[0].targetItem == "6") &&
            (rows[2].targetItem == "6") &&
            (rows[4].targetItem == "6") && !MainUI.Item3Bought)

            prizeValue = -800;

        else if (
            (rows[1].targetItem == "Cherry") &&
            (rows[2].targetItem == "Cherry") &&
            (rows[3].targetItem == "Cherry") && !MainUI.Item3Bought)

            prizeValue = 250; 
        
        else if (
            (rows[1].targetItem == "Cherry") &&
            (rows[2].targetItem == "Cherry") &&
            (rows[3].targetItem == "Cherry") && MainUI.Item3Bought)

            prizeValue = 50;

        else if (
            (rows[1].targetItem == "Banana") &&
            (rows[2].targetItem == "Banana") &&
            (rows[3].targetItem == "Banana") && !MainUI.Item3Bought)

            prizeValue = 50; 
        
        else if (
            (rows[1].targetItem == "Banana") &&
            (rows[2].targetItem == "Banana") &&
            (rows[3].targetItem == "Banana") && MainUI.Item3Bought)

            prizeValue = 5;

        else if (
            (rows[1].targetItem == "Kiwi") &&
            (rows[2].targetItem == "Kiwi") &&
            (rows[3].targetItem == "Kiwi") && !MainUI.Item3Bought)

            prizeValue = 400; 
        
        else if (
            (rows[1].targetItem == "Kiwi") &&
            (rows[2].targetItem == "Kiwi") &&
            (rows[3].targetItem == "Kiwi") && MainUI.Item3Bought)

            prizeValue = 100;

        else if (
            (rows[1].targetItem == "Orange") &&
            (rows[2].targetItem == "Orange") &&
            (rows[3].targetItem == "Orange") && !MainUI.Item3Bought)

            prizeValue = 50;
        
        else if (
            (rows[1].targetItem == "Orange") &&
            (rows[2].targetItem == "Orange") &&
            (rows[3].targetItem == "Orange") && MainUI.Item3Bought)

            prizeValue = 15;

        else if (
           (rows[1].targetItem == "Grape") &&
           (rows[2].targetItem == "Grape") &&
           (rows[3].targetItem == "Grape") && !MainUI.Item3Bought)

            prizeValue = 50; 
        
        else if (
           (rows[1].targetItem == "Grape") &&
           (rows[2].targetItem == "Grape") &&
           (rows[3].targetItem == "Grape") && MainUI.Item3Bought)

            prizeValue = 20;

        else if (
            (rows[1].targetItem == "Mango") &&
            (rows[2].targetItem == "Mango") &&
            (rows[3].targetItem == "Mango") && !MainUI.Item3Bought)

            prizeValue = 200;
        
        else if (
            (rows[1].targetItem == "Mango") &&
            (rows[2].targetItem == "Mango") &&
            (rows[3].targetItem == "Mango") && MainUI.Item3Bought)

            prizeValue = 100;

        else if (
           (rows[1].targetItem == "7") &&
           (rows[2].targetItem == "7") &&
           (rows[3].targetItem == "7") && !MainUI.Item3Bought)

            prizeValue = 750;
        
        else if (
           (rows[1].targetItem == "7") &&
           (rows[2].targetItem == "7") &&
           (rows[3].targetItem == "7") && MainUI.Item3Bought)

            prizeValue = 300;

        else if (
            (rows[1].targetItem == "6") &&
            (rows[2].targetItem == "6") &&
            (rows[3].targetItem == "6") && MainUI.Item2Bought)

            prizeValue = -850;
        
        else if (
            (rows[1].targetItem == "6") &&
            (rows[2].targetItem == "6") &&
            (rows[3].targetItem == "6") && MainUI.Item3Bought)

            prizeValue = -500;
        
        else if (
            (rows[1].targetItem == "6") &&
            (rows[2].targetItem == "6") &&
            (rows[3].targetItem == "6") && !MainUI.Item3Bought)

            prizeValue = -800;

        else if (
           (rows[0].targetItem == "Cherry") &&
           (rows[1].targetItem == "Cherry") &&
           (rows[2].targetItem == "Cherry") && !MainUI.Item3Bought)

            prizeValue = 250; 
        
        else if (
           (rows[0].targetItem == "Cherry") &&
           (rows[1].targetItem == "Cherry") &&
           (rows[2].targetItem == "Cherry") && MainUI.Item3Bought)

            prizeValue = 50;

        else if (
           (rows[2].targetItem == "Cherry") &&
           (rows[3].targetItem == "Cherry") &&
           (rows[4].targetItem == "Cherry") && !MainUI.Item3Bought)

            prizeValue = 250;
        
        else if (
           (rows[2].targetItem == "Cherry") &&
           (rows[3].targetItem == "Cherry") &&
           (rows[4].targetItem == "Cherry") && MainUI.Item3Bought)

            prizeValue = 50;

        else if (
           (rows[0].targetItem == "Banana") &&
           (rows[1].targetItem == "Banana") &&
           (rows[2].targetItem == "Banana") && !MainUI.Item3Bought)

            prizeValue = 50;
        
        else if (
           (rows[0].targetItem == "Banana") &&
           (rows[1].targetItem == "Banana") &&
           (rows[2].targetItem == "Banana") && MainUI.Item3Bought)

            prizeValue = 5;

        else if (
           (rows[2].targetItem == "Banana") &&
           (rows[3].targetItem == "Banana") &&
           (rows[4].targetItem == "Banana") && !MainUI.Item3Bought)

            prizeValue = 50;
        
        else if (
           (rows[2].targetItem == "Banana") &&
           (rows[3].targetItem == "Banana") &&
           (rows[4].targetItem == "Banana") && MainUI.Item3Bought)

            prizeValue = 5;

        else if (
            (rows[0].targetItem == "Kiwi") &&
            (rows[1].targetItem == "Kiwi") &&
            (rows[2].targetItem == "Kiwi") && !MainUI.Item3Bought)

            prizeValue = 400;
        
        else if (
            (rows[0].targetItem == "Kiwi") &&
            (rows[1].targetItem == "Kiwi") &&
            (rows[2].targetItem == "Kiwi") && MainUI.Item3Bought)

            prizeValue = 100;

        else if (
            (rows[2].targetItem == "Kiwi") &&
            (rows[3].targetItem == "Kiwi") &&
            (rows[4].targetItem == "Kiwi") && !MainUI.Item3Bought)

            prizeValue = 400;
        
        else if (
            (rows[2].targetItem == "Kiwi") &&
            (rows[3].targetItem == "Kiwi") &&
            (rows[4].targetItem == "Kiwi") && MainUI.Item3Bought)

            prizeValue = 100;

        else if (
            (rows[0].targetItem == "Orange") &&
            (rows[1].targetItem == "Orange") &&
            (rows[2].targetItem == "Orange") && !MainUI.Item3Bought)

            prizeValue = 50;
        
        else if (
            (rows[0].targetItem == "Orange") &&
            (rows[1].targetItem == "Orange") &&
            (rows[2].targetItem == "Orange") && MainUI.Item3Bought)

            prizeValue = 15;
        
        else if (
            (rows[2].targetItem == "Orange") &&
            (rows[3].targetItem == "Orange") &&
            (rows[4].targetItem == "Orange") && !MainUI.Item3Bought)

            prizeValue = 50;
        
        else if (
            (rows[2].targetItem == "Orange") &&
            (rows[3].targetItem == "Orange") &&
            (rows[4].targetItem == "Orange") && MainUI.Item3Bought)

            prizeValue = 15;

        else if (
            (rows[0].targetItem == "Grape") &&
            (rows[1].targetItem == "Grape") &&
            (rows[2].targetItem == "Grape") && !MainUI.Item3Bought)

            prizeValue = 50;
        
        else if (
            (rows[0].targetItem == "Grape") &&
            (rows[1].targetItem == "Grape") &&
            (rows[2].targetItem == "Grape") && MainUI.Item3Bought)

            prizeValue = 20;

        else if (
            (rows[2].targetItem == "Grape") &&
            (rows[3].targetItem == "Grape") &&
            (rows[4].targetItem == "Grape") && !MainUI.Item3Bought)

            prizeValue = 50;
        
        else if (
            (rows[2].targetItem == "Grape") &&
            (rows[3].targetItem == "Grape") &&
            (rows[4].targetItem == "Grape") && MainUI.Item3Bought)

            prizeValue = 20;

        else if (
            (rows[0].targetItem == "Mango") &&
            (rows[1].targetItem == "Mango") &&
            (rows[2].targetItem == "Mango") && !MainUI.Item3Bought)

            prizeValue = 200;
        
        else if (
            (rows[0].targetItem == "Mango") &&
            (rows[1].targetItem == "Mango") &&
            (rows[2].targetItem == "Mango") && MainUI.Item3Bought)

            prizeValue = 100;

        else if (
            (rows[2].targetItem == "Mango") &&
            (rows[3].targetItem == "Mango") &&
            (rows[4].targetItem == "Mango") && !MainUI.Item3Bought)

            prizeValue = 200; 
        
        else if (
            (rows[2].targetItem == "Mango") &&
            (rows[3].targetItem == "Mango") &&
            (rows[4].targetItem == "Mango") && MainUI.Item3Bought)

            prizeValue = 100;

        else if (
           (rows[0].targetItem == "7") &&
           (rows[1].targetItem == "7") &&
           (rows[2].targetItem == "7") && !MainUI.Item3Bought)

            prizeValue = 750;
        
        else if (
           (rows[0].targetItem == "7") &&
           (rows[1].targetItem == "7") &&
           (rows[2].targetItem == "7") && MainUI.Item3Bought)

            prizeValue = 300;

        else if (
          (rows[2].targetItem == "7") &&
          (rows[3].targetItem == "7") &&
          (rows[4].targetItem == "7") && !MainUI.Item3Bought)

            prizeValue = 750;
         
        else if (
          (rows[2].targetItem == "7") &&
          (rows[3].targetItem == "7") &&
          (rows[4].targetItem == "7") && MainUI.Item3Bought)

            prizeValue = 300;

        else if (
           (rows[0].targetItem == "6") &&
           (rows[1].targetItem == "6") &&
           (rows[2].targetItem == "6") && MainUI.Item2Bought)

            prizeValue = -850;
        
        else if (
           (rows[0].targetItem == "6") &&
           (rows[1].targetItem == "6") &&
           (rows[2].targetItem == "6") && MainUI.Item3Bought)

            prizeValue = -500;
        
        else if (
           (rows[0].targetItem == "6") &&
           (rows[1].targetItem == "6") &&
           (rows[2].targetItem == "6") && !MainUI.Item3Bought)

            prizeValue = -800;

        else if (
           (rows[2].targetItem == "6") &&
           (rows[3].targetItem == "6") &&
           (rows[4].targetItem == "6") && MainUI.Item2Bought)

            prizeValue = -850;
        
        else if (
           (rows[2].targetItem == "6") &&
           (rows[3].targetItem == "6") &&
           (rows[4].targetItem == "6") && MainUI.Item3Bought)

            prizeValue = -500;
        
        else if (
           (rows[2].targetItem == "6") &&
           (rows[3].targetItem == "6") &&
           (rows[4].targetItem == "6") && !MainUI.Item3Bought)

            prizeValue = -800;

        #endregion

        #region 2-Row Patterns

        else if (
           (rows[0].targetItem == "Cherry") &&
           (rows[1].targetItem == "Cherry") && !MainUI.Item3Bought)

            prizeValue = 50;
        
        else if (
           (rows[0].targetItem == "Cherry") &&
           (rows[1].targetItem == "Cherry") && MainUI.Item3Bought)

            prizeValue = 25;

        else if (
           (rows[1].targetItem == "Cherry") &&
           (rows[3].targetItem == "Cherry") && !MainUI.Item3Bought)

            prizeValue = 50;
        
        else if (
           (rows[1].targetItem == "Cherry") &&
           (rows[3].targetItem == "Cherry") && MainUI.Item3Bought)

            prizeValue = 25;

        else if (
           (rows[3].targetItem == "Cherry") &&
           (rows[4].targetItem == "Cherry") && !MainUI.Item3Bought)

            prizeValue = 50;
        
        else if (
           (rows[3].targetItem == "Cherry") &&
           (rows[4].targetItem == "Cherry") && MainUI.Item3Bought)

            prizeValue = 25;

        else if (
          (rows[0].targetItem == "Banana") &&
          (rows[1].targetItem == "Banana") && !MainUI.Item3Bought)

            prizeValue = 5; 
        
        else if (
          (rows[0].targetItem == "Banana") &&
          (rows[1].targetItem == "Banana") && MainUI.Item3Bought)

            prizeValue = 3;

        else if (
          (rows[1].targetItem == "Banana") &&
          (rows[3].targetItem == "Banana") && !MainUI.Item3Bought)

            prizeValue = 5;
        
        else if (
          (rows[1].targetItem == "Banana") &&
          (rows[3].targetItem == "Banana") && MainUI.Item3Bought)

            prizeValue = 3;

        else if (
         (rows[3].targetItem == "Banana") &&
         (rows[4].targetItem == "Banana") && !MainUI.Item3Bought)

            prizeValue = 5;
        
        else if (
         (rows[3].targetItem == "Banana") &&
         (rows[4].targetItem == "Banana") && MainUI.Item3Bought)

            prizeValue = 3;

        else if (
            (rows[0].targetItem == "Kiwi") &&
            (rows[1].targetItem == "Kiwi") && !MainUI.Item3Bought)

            prizeValue = 50;
        
        else if (
            (rows[0].targetItem == "Kiwi") &&
            (rows[1].targetItem == "Kiwi") && MainUI.Item3Bought)

            prizeValue = 25;

        else if (
            (rows[1].targetItem == "Kiwi") &&
            (rows[3].targetItem == "Kiwi") && !MainUI.Item3Bought)

            prizeValue = 50;
        
        else if (
            (rows[1].targetItem == "Kiwi") &&
            (rows[3].targetItem == "Kiwi") && MainUI.Item3Bought)

            prizeValue = 25;

        else if (
            (rows[3].targetItem == "Kiwi") &&
            (rows[4].targetItem == "Kiwi") && !MainUI.Item3Bought)

            prizeValue = 50; 
        
        else if (
            (rows[3].targetItem == "Kiwi") &&
            (rows[4].targetItem == "Kiwi") && MainUI.Item3Bought)

            prizeValue = 25;

        else if (
            (rows[0].targetItem == "Orange") &&
            (rows[1].targetItem == "Orange") && !MainUI.Item3Bought)

            prizeValue = 5;
        
        else if (
            (rows[0].targetItem == "Orange") &&
            (rows[1].targetItem == "Orange") && MainUI.Item3Bought)

            prizeValue = 3;

        else if (
            (rows[1].targetItem == "Orange") &&
            (rows[3].targetItem == "Orange") && !MainUI.Item3Bought)

            prizeValue = 5;
        
        else if (
            (rows[1].targetItem == "Orange") &&
            (rows[3].targetItem == "Orange") && MainUI.Item3Bought)

            prizeValue = 3;

        else if (
            (rows[3].targetItem == "Orange") &&
            (rows[4].targetItem == "Orange") && !MainUI.Item3Bought)

            prizeValue = 5;
        
        else if (
            (rows[3].targetItem == "Orange") &&
            (rows[4].targetItem == "Orange") && MainUI.Item3Bought)

            prizeValue = 3;

        else if (
            (rows[0].targetItem == "Grape") &&
            (rows[1].targetItem == "Grape") && !MainUI.Item3Bought)

            prizeValue = 5;
        
        else if (
            (rows[0].targetItem == "Grape") &&
            (rows[1].targetItem == "Grape") && MainUI.Item3Bought)

            prizeValue = 3;

        else if (
            (rows[1].targetItem == "Grape") &&
            (rows[3].targetItem == "Grape") && !MainUI.Item3Bought)

            prizeValue = 5;
        
        else if (
            (rows[1].targetItem == "Grape") &&
            (rows[3].targetItem == "Grape") && MainUI.Item3Bought)

            prizeValue = 3;

        else if (
           (rows[3].targetItem == "Grape") &&
           (rows[4].targetItem == "Grape") && !MainUI.Item3Bought)

            prizeValue = 5; 
        
        else if (
           (rows[3].targetItem == "Grape") &&
           (rows[4].targetItem == "Grape") && MainUI.Item3Bought)

            prizeValue = 3;

        else if (
            (rows[0].targetItem == "Mango") &&
            (rows[1].targetItem == "Mango") && !MainUI.Item3Bought)

            prizeValue = 45;
        
        else if (
            (rows[0].targetItem == "Mango") &&
            (rows[1].targetItem == "Mango") && MainUI.Item3Bought)

            prizeValue = 20;

        else if (
            (rows[1].targetItem == "Mango") &&
            (rows[3].targetItem == "Mango") && !MainUI.Item3Bought)

            prizeValue = 45;
        
        else if (
            (rows[1].targetItem == "Mango") &&
            (rows[3].targetItem == "Mango") && MainUI.Item3Bought)

            prizeValue = 20;

        else if (
            (rows[3].targetItem == "Mango") &&
            (rows[4].targetItem == "Mango") && !MainUI.Item3Bought)

            prizeValue = 45;
        
        else if (
            (rows[3].targetItem == "Mango") &&
            (rows[4].targetItem == "Mango") && MainUI.Item3Bought)

            prizeValue = 20;

        else if (
           (rows[0].targetItem == "7") &&
           (rows[1].targetItem == "7") && !MainUI.Item3Bought)

            prizeValue = 85;
        
        else if (
           (rows[0].targetItem == "7") &&
           (rows[1].targetItem == "7") && MainUI.Item3Bought)

            prizeValue = 50;

        else if (
           (rows[1].targetItem == "7") &&
           (rows[3].targetItem == "7") && !MainUI.Item3Bought)

            prizeValue = 85; 
        
        else if (
           (rows[1].targetItem == "7") &&
           (rows[3].targetItem == "7") && MainUI.Item3Bought)

            prizeValue = 50;

        else if (
           (rows[3].targetItem == "7") &&
           (rows[4].targetItem == "7") && !MainUI.Item3Bought)

            prizeValue = 85;
        
        else if (
           (rows[3].targetItem == "7") &&
           (rows[4].targetItem == "7") && MainUI.Item3Bought)

            prizeValue = 50;

        else if (
          (rows[0].targetItem == "6") &&
          (rows[1].targetItem == "6") && MainUI.Item2Bought)

            prizeValue = -140; 
        
        else if (
          (rows[0].targetItem == "6") &&
          (rows[1].targetItem == "6") && MainUI.Item3Bought)

            prizeValue = -75;
        
        else if (
          (rows[0].targetItem == "6") &&
          (rows[1].targetItem == "6") && !MainUI.Item3Bought)

            prizeValue = -90;

        else if (
          (rows[1].targetItem == "6") &&
          (rows[3].targetItem == "6") && !MainUI.Item3Bought)

            prizeValue = -90;  
        
        else if (
          (rows[1].targetItem == "6") &&
          (rows[3].targetItem == "6") && MainUI.Item2Bought)

            prizeValue = -140; 
       
        else if (
          (rows[1].targetItem == "6") &&
          (rows[3].targetItem == "6") && MainUI.Item3Bought)

            prizeValue = -75;      
        
        else if (
          (rows[3].targetItem == "6") &&
          (rows[4].targetItem == "6") && MainUI.Item2Bought)

            prizeValue = -140;
        
        else if (
          (rows[3].targetItem == "6") &&
          (rows[4].targetItem == "6") && MainUI.Item3Bought)

            prizeValue = -75;

        else if (
          (rows[3].targetItem == "6") &&
          (rows[4].targetItem == "6"))

            prizeValue = -90;

        else if (
          (rows[0].targetItem == "6") &&
          (rows[1].targetItem == "7"))

            prizeValue = 67;
        
        else if (
          (rows[1].targetItem == "6") &&
          (rows[3].targetItem == "7"))

            prizeValue = 67;
        
        else if (
          (rows[3].targetItem == "6") &&
          (rows[4].targetItem == "7"))

            prizeValue = 67;
        #endregion

        resultsChecked = true;
        MainUI.Money = MainUI.Money + prizeValue;
        
        if (prizeValue > 0)
        {
            audioManager.PlaySFX(audioManager.money);
        }

        if (fiveInARow)
        {
            audioManager.PlaySFX(audioManager.fiveInA_Row);
        }
    }
}
