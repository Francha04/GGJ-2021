using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] public Canvas canvas;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    [SerializeField] public ItemOrganizer itemOrganizer;
    [SerializeField] AudioSource sonidoClick;
    [SerializeField] AudioClip pickSound, dropSound;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        itemOrganizer = FindObjectOfType<ItemOrganizer>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        sonidoClick.PlayOneShot(pickSound);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        this.transform.localScale = new Vector3(1f, 1f, 0f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if(!itemOrganizer.mouseInside)
        {
            itemOrganizer.OnItemLeaveBox(this);
        }
        sonidoClick.PlayOneShot(dropSound);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void Immobilize() // Desabilita el drag and drop en el objeto, lo hace inamovible.
    {
        GetComponent<DragAndDrop>().enabled = false;
    }
}
