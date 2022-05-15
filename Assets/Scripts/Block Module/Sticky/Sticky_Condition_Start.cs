using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky_Condition_Start : Sticky
{
    public override void AttachBlock(GameObject enteringGO)
    {
        if (enteringGO.GetComponent<BlockType>().compisitionType == Block_Type_Composition.Condition_Middle)
        {
            enteringGO.transform.SetParent(gameObject.transform.Find("mock").transform);
            enteringGO.transform.SetSiblingIndex(1);
        }
        else
        {
            base.AttachBlock(enteringGO);
        }
    }
}
