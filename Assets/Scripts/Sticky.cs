using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sticky : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject innerGO = eventData.pointerDrag.GetComponent<Draggable>().go;
        innerGO.transform.SetParent(gameObject.transform);
        innerGO.transform.SetSiblingIndex(1);

        CodeBlock inngerGoCB = innerGO.GetComponent<CodeBlock>();
        CodeBlock gameObjectCB = gameObject.GetComponent<CodeBlock>();

        gameObjectCB.setNextBlock(inngerGoCB);
        inngerGoCB.setPreviousBlock(gameObjectCB);
    }
}
