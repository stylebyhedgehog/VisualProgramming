using System;
using System.Collections;
using UnityEngine;

public class Execution : MonoBehaviour
{
    public static Action executionEnded;

    private CodeBlock startBlock;
    private CodeBlock currentBlock;

    private bool isExecuting = false;

    private void Start()
    {
        CodePanel.executeBtnClicked += onStartButtonClick;
    }
    private void onStartButtonClick()
    {
        if (!isExecuting)
        {
            isExecuting = true;
            startBlock = gameObject.GetComponent<CodeBlock>();
            currentBlock = startBlock;
            queryActions(gameObject.transform);
            Coroutine coroutine = StartCoroutine(Execute());
        }
    }

    private void queryActions(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.name != "mock")
            {
                CodeBlock temp = child.gameObject.GetComponent<CodeBlock>();
                if (temp)
                {
                    currentBlock.setNextBlock(temp);
                    temp.setPreviousBlock(currentBlock);
                    currentBlock = temp;
                }
                queryActions(child);
            }
        }
    }
    private IEnumerator Execute()
    {
        CodeBlock codeBlock = startBlock;
        while (codeBlock.getNextBlock() != null)
        {
            codeBlock = codeBlock.getNextBlock();
            codeBlock.makeAction();
            if (codeBlock.gameObject.name == "start" || codeBlock.gameObject.name == "end")
            {
                yield return new WaitForSeconds(0f);
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
            }
        }
        clearConnections(gameObject.transform);
        isExecuting = false;
    }

    private void clearConnections(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.name != "mock")
            {
                CodeBlock temp = child.gameObject.GetComponent<CodeBlock>();
                if (temp)
                {
                    temp.disconnectPreviousBlock();
                }
                clearConnections(child);
            }
        }
    }
}
