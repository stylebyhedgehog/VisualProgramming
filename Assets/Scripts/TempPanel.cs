using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TempPanel : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject innerGO = eventData.pointerDrag.GetComponent<Draggable>().go;

        Destroy(innerGO);

    }
}
