using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AdDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    float mouseX;
    float mouseY;

    public float investChance;

    Animator anim;
    [SerializeField] private Sprite[] Ads;
    [SerializeField] private Sprite currentSprite;
    
    [SerializeField] private Sprite Invest;
    [SerializeField] private Sprite Sell;

    private Image image;

    public bool invest;

    public float prizeValue;
    public float energyUsed;
    public TextMeshProUGUI prizeReward;
    public TextMeshProUGUI energyDisplay;

    Vector2 difference;
    Vector2 randomPosition;
    [SerializeField] private float xRange = 100f;
    [SerializeField] private float yRange = 100f;

    public Vector3 mousePosition;

    void Awake()
    {
        investChance = Random.Range(0, 2);
    }


    void Start()
    {
        image = GetComponent<Image>();
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        anim = GetComponent<Animator>();

        if (investChance == 1)
        {
            invest = true;
            print("true");
        }
        else if (investChance == 0)
        {
            invest = false;
            print("flase");
        }

        if (image.sprite != Invest /*|| image.sprite != Sell*/)
        {
            currentSprite = Ads[Random.Range(0, Ads.Length)];
            image.sprite = currentSprite;
        }

        else if (image.sprite == Invest || image.sprite == Sell)
        {
            if (invest)
                currentSprite = Ads[0];    //Ads[Random.Range(0, 1)];
            else if (!invest)
                currentSprite = Ads[1];    //Ads[Random.Range(1, 2)];

            image.sprite = currentSprite;
        }
        

        float xPosition = Random.Range(0 - xRange, 0 + xRange);
        float yPosition = Random.Range(0 - yRange, 0 + yRange);

        randomPosition = new Vector2(xPosition, yPosition);
        transform.localPosition = randomPosition;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        mousePosition = Input.mousePosition;        
        difference = transform.position - mousePosition;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (MainUI.Energy >= 1)
        {
            transform.position = eventData.position + difference;
        }

        else
            transform.position = transform.position;
        
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {

    }

    public void ButtonDestroy()
    {
        if (MainUI.Energy >= 1)
        {
            StartCoroutine(AnimationHandler());
        }
    }

    IEnumerator AnimationHandler()
    {
        anim.SetTrigger("Close");
        yield return new WaitForSeconds(0.11f);
        Destroy(gameObject);
    }

   
}
