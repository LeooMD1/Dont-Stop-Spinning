using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Row : MonoBehaviour
{   
    private float randomValue;
    public float timeInterval;
    public Button button;

    [SerializeField]
    private Animator anim;

    //float[] itemPositions = { -330f, -230f, -155f, -70f, 25f, 110f, 210f, 290f };
    Dictionary<string, float> itemPos = new(){
        {"Cherry", -369f},
        {"Banana", -266f},
        {"Kiwi", -190f},
        {"Orange", -100f},
        {"Grape", 126f},
        {"Mango", 0f},
        {"7", 225f},
        {"6", 330f},

    };

    public float minYPos = -420f;
    public float maxYPos = 385f;
    
    public float RNG;
    private static float numberOfSpins;

    public float offset1;
    public float offset2;
    public float newAmount;
    public float newAmountText;
    public string targetItem;

    public bool canSpin;
    public bool hasMoney;

    private void Start()
    {
        offset1 = -368;


        button.onClick.AddListener(OnClick);
        anim = GetComponent<Animator>();
        
    }

    void OnClick()
    {
        
        if (MainUI.Item1Bought)
        {
            newAmount = -33f;
            MainUI.Money += newAmount;
        }

        else if (MainUI.Item1Bought && MainUI.Item3Bought)
        {
            newAmount = -20f;
            MainUI.Money += newAmount;
        }

        else if (MainUI.Item3Bought)
        {
            newAmount = -2f;
            MainUI.Money += newAmount;
        }

        else
        {
            newAmount = -3f;
            MainUI.Money += newAmount;
        }
        if (MainUI.Money >= newAmount * -5)
        {

            if (canSpin && hasMoney && MainUI.Energy > 0)
            {
                //this is the base RNG without any Items
                MainUI.Energy -= 0.2f;
                RNG = Random.Range(0, 100);
                numberOfSpins += 1;
                print(numberOfSpins);

                if (numberOfSpins <= 5)
                {
                    targetItem = new string[] { "Banana", "Kiwi" }[Random.Range(0, 1)];
                }

                else if (numberOfSpins >= 145 && numberOfSpins <= 150)
                {
                    targetItem = new string[] { "Mango", "6" }[Random.Range(0, 1)];
                    print("holy debt");
                }

                else if (numberOfSpins >= 500 && numberOfSpins <= 505)
                {
                    targetItem = new string[] { "7", "Banana" }[Random.Range(0, 1)];
                    print("holy undebt");
                }

                else if (MainUI.Item1Bought)
                {
                    if (RNG <= 5)
                        targetItem = new string[] { "Grape", "Banana", "Orange", "6" }[Random.Range(0, 3)];

                    else if (RNG > 5 && RNG <= 85)
                        targetItem = new string[] { "Cherry", "Kiwi", "Mango", "6" }[Random.Range(0, 3)];

                    else
                        targetItem = new string[] { "7", "6" }[Random.Range(0, 2)];


                }

                else if (MainUI.Item2Bought)
                {
                    if (RNG <= 70)
                        targetItem = new string[] { "Grape", "Banana", "Orange", "6" }[Random.Range(0, 3)];

                    else if (RNG > 70 && RNG <= 85)
                        targetItem = new string[] { "Cherry", "Kiwi", "Mango", "6" }[Random.Range(0, 3)];

                    else if (RNG > 85 && RNG <=95)
                        targetItem = new string[] { "7", "6" }[Random.Range(0, 2)];
                    else
                        targetItem = new string[] { "6", "7" }[Random.Range(0, 1)];

                }

                else
                {
                    if (RNG <= 70)
                        targetItem = new string[] { "Grape", "Banana", "Orange", "6" }[Random.Range(0, 3)];

                    else if (RNG > 70 && RNG <= 90)
                        targetItem = new string[] { "Cherry", "Kiwi", "Mango", "6" }[Random.Range(0, 3)];

                    else
                        targetItem = new string[] { "7", "6" }[Random.Range(0, 2)];
                }
            
            
            
            
            

                print(offset1);

                StartCoroutine(animStuff());
            }
        }
        
    }

    private IEnumerator animStuff()
    {
        anim.SetTrigger("startSpin");

        yield return new WaitForSeconds(2.5f);

        anim.SetTrigger("endSpin");

    }

    public void SetOffs1()
    {   
        offset1 = itemPos[targetItem];
        print("set offset");
    }

    private void Update()
    {
        newAmountText = newAmount * 5;
        
        transform.localPosition = new(transform.localPosition.x, Wrap(offset1 + offset2, minYPos, maxYPos), transform.localPosition.z);

        if (MainUI.Money >= newAmount * -5)
            hasMoney = true;
        else 
            hasMoney = false;
        
    }

    float Wrap(float value, float min, float max)
    {
        return (value - min) % (max - min) + min;
    }
}   
