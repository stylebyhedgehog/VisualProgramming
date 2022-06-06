using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : CodeBlock
{
    public override void makeAction()
    {
        PlayerController.Instance.moveF();
    }
}
