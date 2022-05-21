using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Execution : MonoBehaviour
{
    public static Execution Instance;

    public static Action executionEnded;
    public static Action executionStarted;

    private CodeBlock startBlock;
    private CodeBlock currentBlock;
    private bool isExecuting = false;




    public void onStartButtonClick()
    {
        if (!isExecuting)
        {
            Repository_Level.Instance.attempts += 1;
            Repository_Level.Instance.isRequireBlockUsed = false;
            executionStarted?.Invoke();
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
                checkForRequireBlock(child.gameObject);
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
        GameObject player = GameObject.FindWithTag("Player");
        if (player)
        {
            player.GetComponent<Movement>().setStartPoin(Controller_Level.GetCurrentLevel());
        }
     
    }

    private void checkForRequireBlock(GameObject block)
    {
        if (block.GetComponent<BlockType>() != null)
        {
            Block_Type_Purpose action = block.GetComponent<BlockType>().purposeType;
            Debug.Log(Controller_Level.GetCurrentLevel().Index);
            if (Controller_Level.GetCurrentLevel().requiredBlocks.Contains(action))
            {
                Repository_Level.Instance.isRequireBlockUsed = true;
            }
        }
       

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
