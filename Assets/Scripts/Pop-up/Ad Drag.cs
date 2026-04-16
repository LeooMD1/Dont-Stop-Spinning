using UnityEngine;
using UnityEngine.EventSystems;

public class AdDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
    
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        
    }

}
