using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loop_Start : CodeBlock
{
    [SerializeField] private Text counterText;
    private int counter_value;
    [SerializeField] private CodeBlock loop_end;
    private CodeBlock block_after_loop;
    private bool isFirstIteration = true;
    public override void makeAction()
    {
        if (isFirstIteration)
        {
            if (counterText.text.Length == 0)
            {
                Alert.Instance.showText("Измени количество повторений цикла");
                return;
            }
            counter_value = int.Parse(counterText.text);
            block_after_loop = loop_end.getNextBlock();
            loop_end.setNextBlock(this);
            isFirstIteration = false;
        }
        if (counter_value >= 2)
        {
            counter_value = counter_value - 1;
        }
        else
        {
            loop_end.setNextBlock(block_after_loop);
            isFirstIteration = true;
        }
    }
}


