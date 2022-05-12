using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky_Condition : Sticky
{
    public override void AttachBlock(GameObject enteringGO)
    {
        if (enteringGO.name == "component")
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
