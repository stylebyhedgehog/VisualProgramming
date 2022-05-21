using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler, IEndDragHandler
{
    public GameObject go;
    public Canvas canvas;
    public CanvasGroup canvasGroup;
    public GameObject executablePanel;

    private bool canDuplicate = true;

    public GameObject leftTop;
    public GameObject rightBot;

    public static Action startBlockDropped;

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
            Debug.Log("star drag");
            go = Instantiate(gameObject, GetMousePos(), Quaternion.identity, executablePanel.transform);
            go.name = gameObject.name; // IdDatabase.Instance.getId().ToString();
            go.GetComponent<RectTransform>().position += new Vector3(0,0.5f, 0);
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

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("dragged");
        go.GetComponent<Draggable>().canvasGroup.blocksRaycasts = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        if (leftTop.transform.position.x >= go.transform.position.x
            || leftTop.transform.position.y <= go.transform.position.y
            || rightBot.transform.position.x <= go.transform.position.x
            || rightBot.transform.position.y >= go.transform.position.y)
        {
            Destroy(go);
            Debug.Log("destroyed");
        }
        else
        {
 
            startBlockDropped?.Invoke();
        }
  
      
    }

}
