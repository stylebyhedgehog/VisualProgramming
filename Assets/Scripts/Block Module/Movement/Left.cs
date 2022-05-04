using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : CodeBlock
{
    public override void makeAction()
    {
        Debug.Log("left");
        PlayerController.Instance.rotateL();
    }
}
