using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky_Condition_Completion : Sticky
{
    public override void AttachBlock(GameObject enteringGO)
    {
        Debug.Log("Невозможно прикрепить блок");
    }
}
