using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpongeDrap : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Image Image;

    private BoxCollider2D Collider;
    [SerializeField] private BoxCollider2D sinkCol;

    private bool inSink;
    private bool isCleaned;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Image = GetComponent<Image>();
        Collider = GetComponent<BoxCollider2D>();
        inSink = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position; // follow the mouse
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = new(300, 35, transform.localPosition.z);
    }
}
