
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Sticky : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (gameObject.transform.parent.name != "Content" && eventData.pointerDrag.GetComponent<Draggable>()!=null)
        {
            GameObject enteringGO = eventData.pointerDrag.GetComponent<Draggable>().go;
            if (enteringGO.GetComponent<BlockType>().purposeType != Block_Type_Purpose.Start_Script)
            {
                AttachBlock(enteringGO);
            }
        }
    }
    public virtual void AttachBlock(GameObject enteringGO)
    {
        if (enteringGO.GetComponent<BlockType>().compisitionType == Block_Type_Composition.Basic)
        {
            enteringGO.transform.SetParent(gameObject.transform);
            enteringGO.transform.SetSiblingIndex(1);
        }
    }
}
