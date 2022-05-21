using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable_Composite : Draggable
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        if (go.name == "cycle" || go.name == "condition")
        {
            go.transform.Find("end").gameObject.SetActive(true);
        }
    }
}
