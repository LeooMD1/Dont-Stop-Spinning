using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Sprite Day;
    [SerializeField] private Sprite Midday;
    [SerializeField] private Sprite Night;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MainUI.Energy >= 5)
        {
            backgroundImage.sprite = Day;
        }

        if (MainUI.Energy < 5 && MainUI.Energy > 2)
        {
            backgroundImage.sprite = Midday;
        }

        else if (MainUI.Energy < 2)
        {
            backgroundImage.sprite = Night;
        }
    }
}
