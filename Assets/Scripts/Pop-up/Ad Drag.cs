using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AdDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    float mouseX;
    float mouseY;

    Animator anim;
    [SerializeField] private Sprite[] Ads;
    [SerializeField] private Sprite currentSprite;
    private Image image;

    Vector2 difference;
    Vector2 randomPosition;
    [SerializeField] private float xRange = 100f;
    [SerializeField] private float yRange = 100f;

    public Vector3 mousePosition;
    

    void Start()
    {
        image = GetComponent<Image>();
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        anim = GetComponent<Animator>();

        currentSprite = Ads[Random.Range(0, Ads.Length)];
        image.sprite = currentSprite;

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
        transform.position = eventData.position + difference;
        
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {

    }

    public void ButtonDestroy()
    {
        StartCoroutine(AnimationHandler());
    }

    IEnumerator AnimationHandler()
    {
        anim.SetTrigger("Close");
        yield return new WaitForSeconds(0.11f);
        Destroy(gameObject);
    }
}
