using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PlateDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Image Image;
    private Animator plateAnim;
    [SerializeField] private TextMeshProUGUI prizeReward;
    [SerializeField] private TextMeshProUGUI energyDisplay;
    private float prizeValue;
    private float energyUsed;

    
    private BoxCollider2D Collider;
    [SerializeField] private BoxCollider2D sinkCol;
    [SerializeField] private BoxCollider2D spongeCol;
    [SerializeField] private BoxCollider2D cleanPlateCheckCol;
    [SerializeField] private GameObject leave;


    [SerializeField] private Transform PlateStuff;
    [SerializeField] private AudioManager audioManager;

    public bool inSink;
    public bool plateCleaned;
    private Vector3 plateStartPos;

    [SerializeField] private Sprite cleanPlate;
    [SerializeField] private Sprite currentSprite;
    [SerializeField] private Sprite[] dirtyPlates;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Image = GetComponent<Image>();
        Collider = GetComponent<BoxCollider2D>();
        plateAnim = GetComponent<Animator>();
        inSink = false;


        leave.SetActive(false);

        currentSprite = dirtyPlates[Random.Range(0, dirtyPlates.Length)];
        Image.sprite = currentSprite;

        plateStartPos = new Vector3(280, -80, 0);

        prizeReward.color = Color.green;
    }

    void Update()
    {
        if (MainUI.Money >= 15 || MainUI.Energy < 1)
            leave.SetActive(true);
        else
            leave.SetActive(false);
        
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!plateCleaned && MainUI.Energy >= 1)
        Image.color = new Color32(255, 255, 255, 170);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!plateCleaned && MainUI.Energy >= 1)
        transform.position = eventData.position; // follow the mouse
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Image.color = new Color32(255, 255, 255, 255);

        if (Physics2D.IsTouching(Collider, sinkCol))
        {
            transform.localPosition = new(0, -98.1f, transform.localPosition.z);
            print("Sink Teleport works");
            inSink = true;
            audioManager.PlaySFX(audioManager.plateInWater);

            

        }
        
        else 
            inSink = false;

        if (Physics2D.IsTouching(Collider, cleanPlateCheckCol) && Image.sprite == cleanPlate)
        {
            if (!plateCleaned)
            {
                GameObject newPlate = Instantiate(gameObject, PlateStuff);
                newPlate.transform.localPosition = plateStartPos;
                newPlate.transform.localPosition = new(300, -80, transform.localPosition.z);
                spongeCol.gameObject.GetComponent<SpongeDrap>().plateCol = newPlate.GetComponent<BoxCollider2D>();
                spongeCol.gameObject.GetComponent<SpongeDrap>().plateDrag = newPlate.GetComponent<PlateDrag>();
                spongeCol.gameObject.GetComponent<SpongeDrap>().plateImage = newPlate.GetComponent<Image>();
            }

            transform.localPosition = new(-280, -95f, transform.localPosition.z);
            plateCleaned = true;

            if (plateCleaned)
                StartCoroutine(DestroyPlate());
        }

        else
            plateCleaned = false;
    }

    private IEnumerator DestroyPlate()
    {
        prizeValue = 10;
        prizeReward.text = "+$" + prizeValue.ToString();
        prizeReward.enabled = true;

        energyUsed = -1;
        energyDisplay.text = energyUsed.ToString();
        energyDisplay.enabled = true;

        yield return new WaitForSeconds(0.2f);

        MainUI.Money += prizeValue;
        audioManager.PlaySFX(audioManager.money);
        prizeReward.enabled = false;

        MainUI.Energy += energyUsed;
        energyDisplay.enabled = false;

        plateAnim.SetTrigger("plateDestroy");
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
