
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Sticky : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (gameObject.transform.parent.name != "Content")
        {
            GameObject enteringGO = eventData.pointerDrag.GetComponent<Draggable>().go;
            AttachBlock(enteringGO);
        }
    }

    public virtual void AttachBlock(GameObject enteringGO)
    {
        enteringGO.transform.SetParent(gameObject.transform);
        enteringGO.transform.SetSiblingIndex(1);
    }
}
