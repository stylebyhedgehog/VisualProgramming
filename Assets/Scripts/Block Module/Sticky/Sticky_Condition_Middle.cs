using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky_Condition_Middle : Sticky
{
    public override void AttachBlock(GameObject enteringGO)
    {
        if (enteringGO.GetComponent<BlockType>().compisitionType == Block_Type_Composition.Condition_Completion)
        {
            enteringGO.transform.SetParent(gameObject.transform.Find("mock").transform);
        }
    }
}