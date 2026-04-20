using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpongeDrap : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Image Image;

    [SerializeField] public Image plateImage;

    private BoxCollider2D spongeCol;

    [SerializeField] private Sprite Soap;
    [SerializeField] private Sprite cleanPlate;
    [SerializeField] private Sprite[] dirtyPlate;
    [SerializeField] private Sprite cleanSponge;
    [SerializeField] private Sprite Sponge;

    [SerializeField] private AudioManager audioManager;
    [SerializeField] private Animator soapAnim;
    

    [SerializeField] public BoxCollider2D plateCol;
    [SerializeField] private BoxCollider2D soapCol;
    public PlateDrag plateDrag;

    public bool isCleaning;
    bool isPlayingBubbleSound;

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
            audioManager.PlaySFX(audioManager.bubbles);
            Image.sprite = cleanSponge;
        }
        
        if (Physics2D.IsTouching(spongeCol, plateCol) && plateDrag.inSink && plateImage.sprite != Soap && plateImage.sprite != cleanPlate && Image.sprite == cleanSponge)
        {
            StartCoroutine(WashDish());
            if (!isPlayingBubbleSound)
            {
                audioManager.PlaySFX(audioManager.Sponge);
                isPlayingBubbleSound = true;
            }
            

        }

        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = new(155, 0, transform.localPosition.z);
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
        isPlayingBubbleSound = false;
    }

    void Update()
    {
        if (Physics2D.IsTouching(spongeCol, plateCol))
            isCleaning = true;

        else
            isCleaning = false;
    }
}
