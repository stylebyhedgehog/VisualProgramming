using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sticky : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (gameObject.transform.parent.name != "Content")
        {
            GameObject innerGO = eventData.pointerDrag.GetComponent<Draggable>().go;
            innerGO.transform.SetParent(gameObject.transform);
            innerGO.transform.SetSiblingIndex(1);

            CodeBlock inngerGoCB = innerGO.GetComponent<CodeBlock>();
            CodeBlock gameObjectCB = gameObject.GetComponent<CodeBlock>();

            
            if (gameObjectCB.hasNextBlock())
            {
                CodeBlock bottomBlock = gameObjectCB.getNextBlock();
                CodeBlock lastBlockInChain = inngerGoCB.getLastBlockInChain();
                lastBlockInChain.setNextBlock(bottomBlock);
                bottomBlock.setPreviousBlock(lastBlockInChain);
            }
            gameObjectCB.setNextBlock(inngerGoCB);
            inngerGoCB.setPreviousBlock(gameObjectCB);
        }
      
    }
}
