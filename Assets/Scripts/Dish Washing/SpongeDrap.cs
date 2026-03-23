using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpongeDrap : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Image Image;

    [SerializeField] Image plateImage;

    private BoxCollider2D spongeCol;

    [SerializeField] private Sprite Soap;
    [SerializeField] private Sprite cleanPlate;
    [SerializeField] private Sprite[] dirtyPlate;
    [SerializeField] private Sprite cleanSponge;
    [SerializeField] private Sprite Sponge;

    [SerializeField] private Animator soapAnim;

    [SerializeField] private BoxCollider2D plateCol;
    [SerializeField] private BoxCollider2D soapCol;
    public PlateDrag plateDrag;

    public bool isCleaning;


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
        
        if (Physics2D.IsTouching(spongeCol, soapCol) && Image.sprite == Sponge)
        {
            soapAnim.SetTrigger("Soaped");
            Image.sprite = cleanSponge;
        }
        
        if (Physics2D.IsTouching(spongeCol, plateCol) && plateDrag.inSink && plateImage.sprite != Soap && plateImage.sprite != cleanPlate && Image.sprite == cleanSponge)
            StartCoroutine(WashDish());

        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //transform.localPosition = new(300, 35, transform.localPosition.z);
    }

    private IEnumerator WashDish()
    {
        
        
        yield return new WaitForSeconds(2.5f);

        if (isCleaning)
        plateImage.sprite = Soap;

        yield return new WaitForSeconds(2.5f);

        if (isCleaning)
        plateImage.sprite = cleanPlate;

        Image.sprite = Sponge;
    }

    void Update()
    {
        if (Physics2D.IsTouching(spongeCol, plateCol))
            isCleaning = true;

        else
            isCleaning = false;
    }
}
