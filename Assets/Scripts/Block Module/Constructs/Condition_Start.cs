using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition_Start : CodeBlock
{
    private Condition_Middle conditionMiddle;
    private Condition_Completion conditionCompletion;
    private CodeBlock condition_end;
    private CodeBlock block_after_condition;

    public override void makeAction()
    {
        Debug.Log("condition start");
        executeCondition();
    }

    private void executeCondition()
    {
        getConditionMiddleAndCompletion(gameObject.transform);
        Debug.Log(conditionMiddle.gameObject.name);
        Debug.Log(conditionCompletion.gameObject.name);
        condition_end = gameObject.transform.parent.Find("end").GetComponent<CodeBlock>();
        block_after_condition = condition_end.getNextBlock();
        if (!isConditionTrue())
        {
            this.setNextBlock(block_after_condition);
        }
    }

    private void getConditionMiddleAndCompletion(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.name != "mock")
            {
                if (child.gameObject.GetComponent<BlockType>().compisitionType == Block_Type_Composition.Condition_Middle)
                {
                    conditionMiddle = child.gameObject.GetComponent<Condition_Middle>();
                }
                if (child.gameObject.GetComponent<BlockType>().compisitionType == Block_Type_Composition.Condition_Completion)
                {
                    conditionCompletion = child.gameObject.GetComponent<Condition_Completion>();
                }
            }
            getConditionMiddleAndCompletion(child);

        }
    }

    private bool isConditionTrue()
    {
        if (conditionCompletion.type == Condition_Completion_Type.Obstacle)
        {
            switch (conditionMiddle.type)
            {
                case Condition_Middle_Type.Movement_Forward:
                    return PlayerController.Instance.isObstacleForward();
                case Condition_Middle_Type.Movement_Backward:
                    return PlayerController.Instance.isObstacleBackward();
                case Condition_Middle_Type.Movement_Right:
                    return PlayerController.Instance.isObstacleRight();
                case Condition_Middle_Type.Movement_Left:
                    return PlayerController.Instance.isObstacleLeft();
                default:
                    return false;
            }

        }
        return false;
      
    }
}
