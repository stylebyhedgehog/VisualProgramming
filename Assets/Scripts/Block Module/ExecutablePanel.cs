
using UnityEngine;
using UnityEngine.EventSystems;

public class ExecutablePanel : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.GetComponent<Draggable>())
        {
            Debug.Log("dropped");
             GameObject innerGO = eventData.pointerDrag.GetComponent<Draggable>().go;
             innerGO.transform.SetParent(gameObject.transform);
        }
       
    }
}
