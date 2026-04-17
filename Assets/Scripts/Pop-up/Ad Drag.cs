using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class AdDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    float mouseX;
    float mouseY;

    Animator anim;
    [SerializeField] private Sprite[] Ads;
    [SerializeField] private Sprite currentSprite;

    Vector2 difference;

    public Vector3 mousePosition;
    

    void Start()
    {
        
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        anim = GetComponent<Animator>();

        currentSprite = Ads[Random.Range(0, Ads.Length)];
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
