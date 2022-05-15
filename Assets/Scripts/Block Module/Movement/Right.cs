using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : CodeBlock
{
    public override void makeAction()
    {
        Debug.Log("right");
        PlayerController.Instance.moveR();
    }
}
