using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : CodeBlock
{
    public override void makeAction()
    {
        Debug.Log("forward");
        PlayerController.Instance.moveF();
    }
   
}
