using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoapDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Image Image;

    [SerializeField] Image spongeImage;

    private BoxCollider2D Collider;
    [SerializeField] BoxCollider2D spongeCol;

    private Animator anim;
    
    [SerializeField] private Sprite cleanSponge;
    [SerializeField] private Sprite Sponge;




    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Image = GetComponent<Image>();
        Collider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {


    }

    public void OnBeginDrag(PointerEventData eventData)
    {
      
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;

        if (Physics2D.IsTouching(Collider, spongeCol) && Image.sprite == Sponge)
        {
            anim.SetTrigger("Soaped");
            spongeImage.sprite = cleanSponge;
        }// follow the mouse
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = new(-149.5f, 11.111f, transform.localPosition.z);
        
    }
}
