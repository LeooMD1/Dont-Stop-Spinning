using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Sprite Day;
    [SerializeField] private Sprite Night;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MainUI.Energy >= 3)
        {
            backgroundImage.sprite = Day;
        }

        else if (MainUI.Energy < 3)
        {
            backgroundImage.sprite = Night;
        }
    }
}
