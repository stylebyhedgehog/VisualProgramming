using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sticky : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject innerGO = eventData.pointerDrag.gameObject;
        innerGO.transform.SetParent(gameObject.transform);
        innerGO.transform.SetSiblingIndex(1);

    }

  
}
