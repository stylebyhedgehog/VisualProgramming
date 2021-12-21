using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler, IEndDragHandler
{
    private GameObject go;
    [SerializeField] private Canvas canvas;
    [SerializeField] protected GameObject block;
    [SerializeField] protected GameObject temp;
    public CanvasGroup canvasGroup;
    [SerializeField] private GameObject executablePanel;
    public bool canDuplicate = true;

    private Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canDuplicate)
        {
            go = Instantiate(gameObject, GetMousePos(), Quaternion.identity, executablePanel.transform);
            go.name = gameObject.name[0] + IdDatabase.Instance.getId().ToString();

        }
        else { go = gameObject; }

        go.GetComponent<Draggable>().canDuplicate = false;

        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;


       

    }

    public void OnDrag(PointerEventData eventData)
    {
        go.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnDrop(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (go.GetComponent<Sticky>() == null)
        {
            go.AddComponent<Sticky>();

        }
        canvasGroup.blocksRaycasts = true;

        canvasGroup.alpha = 1f;
    }

}
