using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;
   // [SerializeField] private Transform dragSlot;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private RectTransform dragLayer;

    public static Block block;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        dragLayer = GameObject.FindGameObjectWithTag("DragLayer").GetComponent<RectTransform>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        block = this;

        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }


    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        SetItemToSlot(dragLayer);
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        
        block = null;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        transform.localPosition = Vector3.zero;
        SetItemToSlot(canvas.transform);
    }

    public void SetItemToSlot(Transform slot)
    {
        transform.SetParent(slot);
    }

}
