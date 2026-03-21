using UnityEngine;
using TMPro;

public class EnergyText : MonoBehaviour
{
    public MainUI mainUI;
    public Font[] fonts;

    private TextMeshProUGUI energyText;


    void Start()
    {
        energyText = GetComponent<TextMeshProUGUI>();

        for (int i = 0; i < fonts.Length; i++)
        {
            fonts[i].material.mainTexture.filterMode = FilterMode.Point;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Mathf.RoundToInt(MainUI.Energy);
        Mathf.FloorToInt(MainUI.Energy);
        energyText.text = (MainUI.Energy.ToString());
    }
}
