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

    private bool resultsChecked = false;
    #endregion

    private void Update()
    {
        if (!rows[0].rowStopped && !rows[1].rowStopped && !rows[2].rowStopped && !rows[3].rowStopped && !rows[4].rowStopped && !resultsChecked)
        {
            prizeValue = 0;
            prizeText.enabled = false;
            resultsChecked = false;
        }

        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && rows[3].rowStopped && rows[4].rowStopped && !resultsChecked)
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
        if (rows[0].stoppedSlot == "Cherry"
            && rows[1].stoppedSlot == "Cherry"
            && rows[2].stoppedSlot == "Cherry"
            && rows[3].stoppedSlot == "Cherry"
            && rows[4].stoppedSlot == "Cherry")

            prizeValue = 500;

        else if (rows[0].stoppedSlot == "Banana"
            && rows[1].stoppedSlot == "Banana"
            && rows[2].stoppedSlot == "Banana"
            && rows[3].stoppedSlot == "Banana"
            && rows[4].stoppedSlot == "Banana")

            prizeValue = 250;

        else if (rows[0].stoppedSlot == "Kiwi"
            && rows[1].stoppedSlot == "Kiwi"
            && rows[2].stoppedSlot == "Kiwi"
            && rows[3].stoppedSlot == "Kiwi"
            && rows[4].stoppedSlot == "Kiwi")

            prizeValue = 800;

        else if (rows[0].stoppedSlot == "Orange"
            && rows[1].stoppedSlot == "Orange"
            && rows[2].stoppedSlot == "Orange"
            && rows[3].stoppedSlot == "Orange"
            && rows[4].stoppedSlot == "Orange")

            prizeValue = 100;

        else if (rows[0].stoppedSlot == "Grape"
            && rows[1].stoppedSlot == "Grape"
            && rows[2].stoppedSlot == "Grape"
            && rows[3].stoppedSlot == "Grape"
            && rows[4].stoppedSlot == "Grape")

            prizeValue = 75;

        else if (rows[0].stoppedSlot == "Mango"
            && rows[1].stoppedSlot == "Mango"
            && rows[2].stoppedSlot == "Mango"
            && rows[3].stoppedSlot == "Mango"
            && rows[4].stoppedSlot == "Mango")

            prizeValue = 400;

        else if (rows[0].stoppedSlot == "7"
            && rows[1].stoppedSlot == "7"
            && rows[2].stoppedSlot == "7"
            && rows[3].stoppedSlot == "7"
            && rows[4].stoppedSlot == "7")

            prizeValue = 1500;

        else if (rows[0].stoppedSlot == "6"
            && rows[1].stoppedSlot == "6"
            && rows[2].stoppedSlot == "6"
            && rows[3].stoppedSlot == "6"
            && rows[4].stoppedSlot == "6")

            prizeValue = -1750;

        else if (
            (rows[0].stoppedSlot == "Cherry") &&
            (rows[2].stoppedSlot == "Cherry") &&
            (rows[4].stoppedSlot == "Cherry"))

            prizeValue = 250;

        else if (
            (rows[0].stoppedSlot == "Banana") &&
            (rows[2].stoppedSlot == "Banana") &&
            (rows[4].stoppedSlot == "Banana"))

            prizeValue = 50;

        else if (
            (rows[0].stoppedSlot == "Kiwi") &&
            (rows[2].stoppedSlot == "Kiwi") &&
            (rows[4].stoppedSlot == "Kiwi"))

            prizeValue = 400;

        else if (
            (rows[0].stoppedSlot == "Orange") &&
            (rows[2].stoppedSlot == "Orange") &&
            (rows[4].stoppedSlot == "Orange"))

            prizeValue = 50;

        else if (
            (rows[0].stoppedSlot == "Grape") &&
            (rows[2].stoppedSlot == "Grape") &&
            (rows[4].stoppedSlot == "Grape"))

            prizeValue = 50;

        else if (
            (rows[0].stoppedSlot == "Mango") &&
            (rows[2].stoppedSlot == "Mango") &&
            (rows[4].stoppedSlot == "Mango"))

            prizeValue = 200;

        else if (
            (rows[0].stoppedSlot == "7") &&
            (rows[2].stoppedSlot == "7") &&
            (rows[4].stoppedSlot == "7"))

            prizeValue = 750;

        else if (
            (rows[0].stoppedSlot == "6") &&
            (rows[2].stoppedSlot == "6") &&
            (rows[4].stoppedSlot == "6"))

            prizeValue = -800;

        resultsChecked = true;      
    }
}
