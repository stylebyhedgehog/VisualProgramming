using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable_Single : Draggable
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
    }
    public override void DuplicateBehaviour()
    {
        base.DuplicateBehaviour();
    }
}
