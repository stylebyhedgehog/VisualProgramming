using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler, IEndDragHandler
{
    public GameObject go;
    [SerializeField] private Canvas canvas;
    [SerializeField] protected GameObject block;
    public CanvasGroup canvasGroup;
    [SerializeField] private GameObject executablePanel;
    public bool canDuplicate = true;

    [SerializeField] private GameObject leftTop;
    [SerializeField] private GameObject rightBot;
    private Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;

        if (canDuplicate)
        {
            go = Instantiate(gameObject, GetMousePos(), Quaternion.identity, executablePanel.transform);
            go.name = gameObject.name[0] + IdDatabase.Instance.getId().ToString();
            go.GetComponent<Draggable>().canDuplicate = false;

        }
        else { go = gameObject; }

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
        go.GetComponent<Draggable>().canvasGroup.blocksRaycasts = true;
   
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        if (leftTop.transform.position.x >= go.transform.position.x
            || leftTop.transform.position.y <= go.transform.position.y
            || rightBot.transform.position.x <= go.transform.position.x
            || rightBot.transform.position.y >= go.transform.position.y)
        {
            Destroy(go);
        }
    }

}
