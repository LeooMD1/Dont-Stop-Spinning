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

    public float offset1;
    public float offset2;
    public string targetItem;

    public bool canSpin;

    private void Start()
    {
        button.onClick.AddListener(OnClick);
        anim = GetComponent<Animator>();
    }

    void OnClick()
    {
        if (canSpin)
        {
            MainUI.Money = MainUI.Money - 10f;
            RNG = Random.Range(0, 100);
            
            if (RNG <= 70)
                targetItem = new string[] { "Cherry", "Banana", "Orange" }[Random.Range(0, 2)];

            else if (RNG > 70 && RNG <= 90)
                targetItem = new string[] { "Kiwi", "Grape", "Mango" }[Random.Range(0, 2)];

            else
                targetItem = new string[] { "7", "6" }[Random.Range(0, 1)];

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
