using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class Typing : MonoBehaviour
{
    public string InputText;
    public TextMeshProUGUI TypingText;

    public string Texts;
    private KeyCode keyCode;
    private KeyCode keyPressed;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputText = TypingText.text;


        if (Input.anyKeyDown && !(Input.GetMouseButtonDown(0)
            || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)))
        {
            print(InputText);  
        }
    }
}
