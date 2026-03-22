using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements.Experimental;
using UnityEditor.Experimental.GraphView;

public class SlotMachine : MonoBehaviour
{
    #region Variables and stuff
    public static event Action ButtonPressed = delegate { };

    [SerializeField]
    private TextMeshProUGUI prizeText;

    [SerializeField]
    private Row[] rows;

    public float prizeValue;

    public bool resultsChecked = false;
    #endregion

    private void Update()
    {
        if (!rows[0].canSpin && !rows[1].canSpin && !rows[2].canSpin && !rows[3].canSpin && !rows[4].canSpin && resultsChecked)
        {
            prizeValue = 0;
            prizeText.enabled = false;
            resultsChecked = false;
        }

        if (rows[0].canSpin && rows[1].canSpin && rows[2].canSpin && rows[3].canSpin && rows[4].canSpin && !resultsChecked)
        {
            CheckResults();
            prizeText.enabled = true;
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
            && rows[4].targetItem == "Cherry")

            prizeValue = 500;

        else if (rows[0].targetItem == "Banana"
            && rows[1].targetItem == "Banana"
            && rows[2].targetItem == "Banana"
            && rows[3].targetItem == "Banana"
            && rows[4].targetItem == "Banana")

            prizeValue = 250;

        else if (rows[0].targetItem == "Kiwi"
            && rows[1].targetItem == "Kiwi"
            && rows[2].targetItem == "Kiwi"
            && rows[3].targetItem == "Kiwi"
            && rows[4].targetItem == "Kiwi")

            prizeValue = 800;

        else if (rows[0].targetItem == "Orange"
            && rows[1].targetItem == "Orange"
            && rows[2].targetItem == "Orange"
            && rows[3].targetItem == "Orange"
            && rows[4].targetItem == "Orange")

            prizeValue = 100;

        else if (rows[0].targetItem == "Grape"
            && rows[1].targetItem == "Grape"
            && rows[2].targetItem == "Grape"
            && rows[3].targetItem == "Grape"
            && rows[4].targetItem == "Grape")

            prizeValue = 75;

        else if (rows[0].targetItem == "Mango"
            && rows[1].targetItem == "Mango"
            && rows[2].targetItem == "Mango"
            && rows[3].targetItem == "Mango"
            && rows[4].targetItem == "Mango")

            prizeValue = 400;

        else if (rows[0].targetItem == "7"
            && rows[1].targetItem == "7"
            && rows[2].targetItem == "7"
            && rows[3].targetItem == "7"
            && rows[4].targetItem == "7")

            prizeValue = 1500;

        else if (rows[0].targetItem == "6"
            && rows[1].targetItem == "6"
            && rows[2].targetItem == "6"
            && rows[3].targetItem == "6"
            && rows[4].targetItem == "6")

            prizeValue = -1750;
        #endregion

        #region 3-Row Pattern
        else if (
            (rows[0].targetItem == "Cherry") &&
            (rows[2].targetItem == "Cherry") &&
            (rows[4].targetItem == "Cherry"))

            prizeValue = 250;

        else if (
            (rows[0].targetItem == "Banana") &&
            (rows[2].targetItem == "Banana") &&
            (rows[4].targetItem == "Banana"))

            prizeValue = 50;

        else if (
            (rows[0].targetItem == "Kiwi") &&
            (rows[2].targetItem == "Kiwi") &&
            (rows[4].targetItem == "Kiwi"))

            prizeValue = 400;

        else if (
            (rows[0].targetItem == "Orange") &&
            (rows[2].targetItem == "Orange") &&
            (rows[4].targetItem == "Orange"))

            prizeValue = 50;

        else if (
            (rows[0].targetItem == "Grape") &&
            (rows[2].targetItem == "Grape") &&
            (rows[4].targetItem == "Grape"))

            prizeValue = 50;

        else if (
            (rows[0].targetItem == "Mango") &&
            (rows[2].targetItem == "Mango") &&
            (rows[4].targetItem == "Mango"))

            prizeValue = 200;

        else if (
            (rows[0].targetItem == "7") &&
            (rows[2].targetItem == "7") &&
            (rows[4].targetItem == "7"))

            prizeValue = 750;

        else if (
            (rows[0].targetItem == "6") &&
            (rows[2].targetItem == "6") &&
            (rows[4].targetItem == "6"))

            prizeValue = -800;

        else if (
            (rows[1].targetItem == "Cherry") &&
            (rows[2].targetItem == "Cherry") &&
            (rows[3].targetItem == "Cherry"))

            prizeValue = 250;

        else if (
            (rows[1].targetItem == "Banana") &&
            (rows[2].targetItem == "Banana") &&
            (rows[3].targetItem == "Banana"))

            prizeValue = 50;

        else if (
            (rows[1].targetItem == "Kiwi") &&
            (rows[2].targetItem == "Kiwi") &&
            (rows[3].targetItem == "Kiwi"))

            prizeValue = 400;

        else if (
            (rows[1].targetItem == "Orange") &&
            (rows[2].targetItem == "Orange") &&
            (rows[3].targetItem == "Orange"))

            prizeValue = 50;

        else if (
           (rows[1].targetItem == "Grape") &&
           (rows[2].targetItem == "Grape") &&
           (rows[3].targetItem == "Grape"))

            prizeValue = 50;

        else if (
            (rows[1].targetItem == "Mango") &&
            (rows[2].targetItem == "Mango") &&
            (rows[3].targetItem == "Mango"))

            prizeValue = 200;

        else if (
           (rows[1].targetItem == "7") &&
           (rows[2].targetItem == "7") &&
           (rows[3].targetItem == "7"))

            prizeValue = 750;

        else if (
            (rows[1].targetItem == "6") &&
            (rows[2].targetItem == "6") &&
            (rows[3].targetItem == "6"))

            prizeValue = -800;
        
        else if (
           (rows[0].targetItem == "Cherry") &&
           (rows[1].targetItem == "Cherry") &&
           (rows[2].targetItem == "Cherry"))

            prizeValue = 250;

        else if (
           (rows[2].targetItem == "Cherry") &&
           (rows[3].targetItem == "Cherry") &&
           (rows[4].targetItem == "Cherry"))

            prizeValue = 250;

        else if (
           (rows[0].targetItem == "Banana") &&
           (rows[1].targetItem == "Banana") &&
           (rows[2].targetItem == "Banana"))

            prizeValue = 50;

        else if (
           (rows[2].targetItem == "Banana") &&
           (rows[3].targetItem == "Banana") &&
           (rows[4].targetItem == "Banana"))

            prizeValue = 50;

        else if (
            (rows[0].targetItem == "Kiwi") &&
            (rows[1].targetItem == "Kiwi") &&
            (rows[2].targetItem == "Kiwi"))

            prizeValue = 400;

        else if (
            (rows[2].targetItem == "Kiwi") &&
            (rows[3].targetItem == "Kiwi") &&
            (rows[4].targetItem == "Kiwi"))

            prizeValue = 400;

        else if (
            (rows[0].targetItem == "Orange") &&
            (rows[1].targetItem == "Orange") &&
            (rows[2].targetItem == "Orange"))

            prizeValue = 50;

        else if (
            (rows[0].targetItem == "Grape") &&
            (rows[1].targetItem == "Grape") &&
            (rows[2].targetItem == "Grape"))

            prizeValue = 50;

        else if (
            (rows[2].targetItem == "Grape") &&
            (rows[3].targetItem == "Grape") &&
            (rows[4].targetItem == "Grape"))

            prizeValue = 50;

        else if (
            (rows[0].targetItem == "Mango") &&
            (rows[1].targetItem == "Mango") &&
            (rows[2].targetItem == "Mango"))

            prizeValue = 200;

        else if (
            (rows[2].targetItem == "Mango") &&
            (rows[3].targetItem == "Mango") &&
            (rows[4].targetItem == "Mango"))

            prizeValue = 200;

        else if (
           (rows[0].targetItem == "7") &&
           (rows[1].targetItem == "7") &&
           (rows[2].targetItem == "7"))

            prizeValue = 750;

        else if (
          (rows[2].targetItem == "7") &&
          (rows[3].targetItem == "7") &&
          (rows[4].targetItem == "7"))

            prizeValue = 750;

        else if (
           (rows[0].targetItem == "6") &&
           (rows[1].targetItem == "6") &&
           (rows[2].targetItem == "6"))

            prizeValue = -800;

        else if (
           (rows[2].targetItem == "6") &&
           (rows[3].targetItem == "6") &&
           (rows[4].targetItem == "6"))

            prizeValue = -800;

        #endregion

        #region 2-Row Patterns

        else if (
           (rows[0].targetItem == "Cherry") &&
           (rows[1].targetItem == "Cherry"))

            prizeValue = 50;

        else if (
           (rows[1].targetItem == "Cherry") &&
           (rows[3].targetItem == "Cherry"))

            prizeValue = 50;

        else if (
           (rows[3].targetItem == "Cherry") &&
           (rows[4].targetItem == "Cherry"))

            prizeValue = 50;

        else if (
          (rows[0].targetItem == "Banana") &&
          (rows[1].targetItem == "Banana"))

            prizeValue = 5;

        else if (
          (rows[1].targetItem == "Banana") &&
          (rows[3].targetItem == "Banana"))

            prizeValue = 5;

        else if (
         (rows[3].targetItem == "Banana") &&
         (rows[4].targetItem == "Banana"))

            prizeValue = 5;

        else if (
            (rows[0].targetItem == "Kiwi") &&
            (rows[1].targetItem == "Kiwi"))

            prizeValue = 50;

        else if (
            (rows[1].targetItem == "Kiwi") &&
            (rows[3].targetItem == "Kiwi"))

            prizeValue = 50;

        else if (
            (rows[3].targetItem == "Kiwi") &&
            (rows[4].targetItem == "Kiwi"))

            prizeValue = 50;
        
        else if (
            (rows[0].targetItem == "Orange") &&
            (rows[1].targetItem == "Orange"))

            prizeValue = 5;

        else if (
            (rows[1].targetItem == "Orange") &&
            (rows[3].targetItem == "Orange"))

            prizeValue = 5;

        else if (
            (rows[3].targetItem == "Orange") &&
            (rows[4].targetItem == "Orange"))

            prizeValue = 5;

        else if (
            (rows[0].targetItem == "Grape") &&
            (rows[1].targetItem == "Grape"))

            prizeValue = 5;

        else if (
            (rows[1].targetItem == "Grape") &&
            (rows[3].targetItem == "Grape"))

            prizeValue = 5;

        else if (
           (rows[3].targetItem == "Grape") &&
           (rows[4].targetItem == "Grape"))

            prizeValue = 5;

        else if (
            (rows[0].targetItem == "Mango") &&
            (rows[1].targetItem == "Mango"))

            prizeValue = 45;

        else if (
            (rows[1].targetItem == "Mango") &&
            (rows[3].targetItem == "Mango"))

            prizeValue = 45;

        else if (
            (rows[3].targetItem == "Mango") &&
            (rows[4].targetItem == "Mango"))

            prizeValue = 45;

        else if (
           (rows[0].targetItem == "7") &&
           (rows[1].targetItem == "7"))

            prizeValue = 85;

        else if (
           (rows[1].targetItem == "7") &&
           (rows[3].targetItem == "7"))

            prizeValue = 85;

        else if (
           (rows[3].targetItem == "7") &&
           (rows[4].targetItem == "7"))

            prizeValue = 85;

        else if (
          (rows[0].targetItem == "6") &&
          (rows[1].targetItem == "6"))

            prizeValue = -90;

        else if (
          (rows[1].targetItem == "6") &&
          (rows[3].targetItem == "6"))

            prizeValue = -90;

        else if (
          (rows[3].targetItem == "6") &&
          (rows[4].targetItem == "6"))

            prizeValue = -90;

        else if (
          (rows[3].targetItem == "6") &&
          (rows[4].targetItem == "7"))

            prizeValue = 67;
        #endregion

        resultsChecked = true;
        MainUI.Money = MainUI.Money + prizeValue;
    }
}
