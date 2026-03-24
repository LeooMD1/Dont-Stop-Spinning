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
        {"Cherry", -330f},
        {"Banana", -230f},
        {"Kiwi", -155f},
        {"Orange", -70f},
        {"Grape", 25f},
        {"Mango", 110f},
        {"7", 210f},
        {"6", 290f},

    };

    public float minYPos = -340f;
    public float maxYPos = 333f;
    
    public float RNG;
    private static float numberOfSpins;

    public float offset1;
    public float offset2;
    public string targetItem;

    public bool canSpin;

    private void Start()
    {
        offset1 = -330f;

        button.onClick.AddListener(OnClick);
        anim = GetComponent<Animator>();
    }

    void OnClick()
    {
        if (canSpin)
        {
            //this is the base RNG without any Items
            MainUI.Money -= 3f;
            MainUI.Energy -= 0.2f;
            RNG = Random.Range(0, 100);
            numberOfSpins += 1;
            print(numberOfSpins);

            if (numberOfSpins <= 5)
            {
                targetItem = new string[] { "Kiwi", "Banana" }[Random.Range(0, 1)];
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

            else
            {
                if (RNG <= 70)
                    targetItem = new string[] { "Grape", "Banana", "Orange", "6" }[Random.Range(0, 4)];

                else if (RNG > 70 && RNG <= 90)
                    targetItem = new string[] { "Kiwi", "Kiwi", "Mango", "6" }[Random.Range(0, 4)];

                else
                    targetItem = new string[] { "7", "6" }[Random.Range(0, 2)];
            }
            
            
            

            print(offset1);

            StartCoroutine(animStuff());
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
        
        transform.localPosition = new(transform.localPosition.x, Wrap(offset1 + offset2, minYPos, maxYPos), transform.localPosition.z);
        
    }

    float Wrap(float value, float min, float max)
    {
        return (value - min) % (max - min) + min;
    }
}   
