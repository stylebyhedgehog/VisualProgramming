
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExecutablePanel : MonoBehaviour, IDropHandler
{
    [SerializeField] public GameObject blocksHolder;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.GetComponent<Draggable>())
        {
            GameObject innerGO = eventData.pointerDrag.GetComponent<Draggable>().go;
            innerGO.transform.SetParent(blocksHolder.transform);
        }
       
    }
}
