using UnityEngine;
using TMPro;

public class MoneyText : MonoBehaviour
{
    public MainUI mainUI;
    public Font[] fonts;
    
    private TextMeshProUGUI moneyText;


    void Start()
    {
        moneyText = GetComponent<TextMeshProUGUI>();

        for (int i = 0; i < fonts.Length; i++)
        {
            fonts[i].material.mainTexture.filterMode = FilterMode.Point;
        }
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + (MainUI.Money.ToString());

        if (MainUI.Money > 0)
            moneyText.color = Color.green;
        else if (MainUI.Money < 0)
            moneyText.color = Color.red;
        else
            moneyText.color = Color.white;
    }
}
