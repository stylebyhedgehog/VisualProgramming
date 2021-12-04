using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Draggable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private GameObject clonedGO;
    [SerializeField] private int canvas;
    [SerializeField] private Canvas canvass;
    [SerializeField] protected GameObject block;
    [SerializeField] private CanvasGroup canvasGroup;

    public void OnBeginDrag(PointerEventData eventData)
    {
        clonedGO = Instantiate(block, gameObject.transform);
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        clonedGO.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas;
    }

    public void OnDrop(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }

}
