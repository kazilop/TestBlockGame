using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;
   
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private RectTransform dragLayer;
    [SerializeField] private ParticleSystem particle;
    private Vector2 startPoint;

    public bool isMovable;

    public static Block block;


    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("PlayCanvas").GetComponent<Canvas>();

        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        dragLayer = GameObject.FindGameObjectWithTag("DragLayer").GetComponent<RectTransform>();
        isMovable = true;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isMovable)
        {
            block = this;

            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
            startPoint = transform.position;
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (isMovable)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            SetItemToSlot(dragLayer);
        }
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        if (isMovable)
        {
            block = null;

            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            transform.localPosition = Vector3.zero;

            if(transform.parent == dragLayer)
            {
                transform.position = startPoint;
            }
        }
    }


    public void SetItemToSlot(Transform slot)
    {
        transform.SetParent(slot);
    }


    public void PlayDestroy()
    {
        var deathFX = Instantiate(particle, transform.position, Quaternion.identity);
        deathFX.Play();
    }
}
