using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loop_Start : CodeBlock
{
    private int counts;
    private CodeBlock loop_end;
    private CodeBlock block_after_loop;
    private bool isFirstIteration = true;

    public override void makeAction()
    {
        Debug.Log("loop staert");
        decreaseAmount();
    }

    private void decreaseAmount()
    {
        if (isFirstIteration)
        {
            counts = int.Parse(gameObject.transform.Find("mock").Find("mock").Find("mock").GetComponent<Text>().text);
            loop_end = gameObject.transform.parent.Find("end").GetComponent<CodeBlock>();
            block_after_loop = loop_end.getNextBlock();
            loop_end.setNextBlock(this);
            isFirstIteration = false;
        }
        if (counts >= 2)
        {
            counts = counts - 1;
        }
        else
        {
            loop_end.setNextBlock(block_after_loop);
            counts = 4;
            isFirstIteration = true;
        }
    }


}

