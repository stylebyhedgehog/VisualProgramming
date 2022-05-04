using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExecutablePanel : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject innerGO = eventData.pointerDrag.GetComponent<Draggable>().go;
        innerGO.transform.SetParent(gameObject.transform);
        CodeBlock innerGoCB = innerGO.GetComponent<CodeBlock>();
        if (innerGoCB.hasPreviousBlock())
        {
       
            innerGoCB.disconnectPreviousBlock();
        }
        
    }
 
}
