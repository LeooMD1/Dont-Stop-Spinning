using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpongeDrap : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Image Image;

    private BoxCollider2D spongeCol;

    [SerializeField] private BoxCollider2D plateCol;
    public PlateDrag plateDrag;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Image = GetComponent<Image>();
        spongeCol = GetComponent<BoxCollider2D>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position; // follow the mouse
        if (Physics2D.IsTouching(spongeCol, plateCol) && plateDrag.inSink)
            StartCoroutine(WashDish());
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //transform.localPosition = new(300, 35, transform.localPosition.z);
    }

    private IEnumerator WashDish()
    {
        return null;
    }
}
