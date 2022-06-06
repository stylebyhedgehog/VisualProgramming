using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable_Start : Draggable
{
    public override void DuplicateBehaviour()
    {
        
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        go.GetComponent<Draggable>().canvasGroup.blocksRaycasts = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        if (leftTop.transform.position.x >= go.transform.position.x
        || leftTop.transform.position.y <= go.transform.position.y
        || rightBot.transform.position.x <= go.transform.position.x
        || rightBot.transform.position.y >= go.transform.position.y)
        {
            go.transform.position = executablePanel.transform.position;
        }
    }
}
