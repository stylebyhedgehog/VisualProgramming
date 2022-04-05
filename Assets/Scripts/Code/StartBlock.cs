using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class StartBlock : MonoBehaviour
{
    CodeBlock executingBlock;

    private void Start()
    {
        CodePanel.closeBtnClicked+= onStartButtonClick;
    }
    private void onStartButtonClick()
    {
        executingBlock = gameObject.GetComponent<CodeBlock>();
        StartCoroutine(Execute());

    }
    private IEnumerator Execute()
    {
        while (executingBlock.getNextBlock() != null)
        {
            executingBlock = executingBlock.getNextBlock();
            executingBlock.makeAction();
            yield return new WaitForSeconds(0.5f);
        }
    }
  
}
