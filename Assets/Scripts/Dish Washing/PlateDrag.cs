using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlateDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Image Image;
    
    private BoxCollider2D Collider;
    [SerializeField] private BoxCollider2D sinkCol;
    [SerializeField] private BoxCollider2D spongeCol;
    [SerializeField] private BoxCollider2D cleanPlateCheckCol;

    [SerializeField] private Transform Background;

    public bool inSink;
    private Vector3 plateStartPos;

    [SerializeField] private Sprite cleanPlate;
    [SerializeField] private Sprite currentSprite;
    [SerializeField] private Sprite[] dirtyPlates;



    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Image = GetComponent<Image>();
        Collider = GetComponent<BoxCollider2D>();
        inSink = false;

        currentSprite = dirtyPlates[Random.Range(0, dirtyPlates.Length)];
        Image.sprite = currentSprite;

        plateStartPos = new Vector3(300, -80, 0);
    }

    void Update()
    {
        
        
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Image.color = new Color32(255, 255, 255, 170);
    }

    public void OnDrag(PointerEventData eventData)
    {
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

            GameObject newPlate = Instantiate(gameObject, Background);
            newPlate.transform.localPosition = plateStartPos;

            if (inSink)
            {
                newPlate.transform.localPosition = new(300, -80, transform.localPosition.z); ;
            }
        }

        else 
            inSink = false;

        if (Physics2D.IsTouching(Collider, cleanPlateCheckCol) && Image.sprite == cleanPlate)
        {
            transform.localPosition = new(-280, -95f, transform.localPosition.z);
        }
    }
}
