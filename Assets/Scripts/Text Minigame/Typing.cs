using Mono.Cecil.Cil;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class Typing : MonoBehaviour
{
    public string InputText;
    public string LastInputText;
    public TextMeshProUGUI TypingText;
    UnityEvent unityEvent = new UnityEvent();

    public TMP_InputField InputField;
    
    public string Texts;
    private KeyCode keyCode;
    private KeyCode keyPressed;


    void Start()
    {
        unityEvent.AddListener(OnKeyPressed);
    }

    // Update is called once per frame
    void Update()
    {
        


        if (Input.anyKeyDown && !(Input.GetMouseButtonDown(0)
            || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)))
        {
            InputText = TypingText.text;
            //print(InputText);  


            LastInputText = InputText;
        }

        //InputSystem.onAnyButtonPress.Call(
        //    button =>
        //    {
        //        if (button is KeyControl key)
        //            Debug.Log($"Key {key.name} pressed! (text: {key.displayName})");
        //    });
    }

    void OnKeyPressed()
    {
        print("bruh");
    }

    public void Test(string text)
    {
        print(text);
        InputField.text = "";
    }
}
