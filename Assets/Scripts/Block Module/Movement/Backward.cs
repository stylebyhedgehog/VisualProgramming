using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backward : CodeBlock
{
    public override void makeAction()
    {
        Debug.Log("backward");
        PlayerController.Instance.moveB();
    }
}
