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

    public bool inSink;
    private bool isCleaned;



    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Image = GetComponent<Image>();
        Collider = GetComponent<BoxCollider2D>();
        inSink = false;
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
        }

        else 
            inSink = false;
    }
}
