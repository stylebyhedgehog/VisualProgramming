using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CodeBlock: MonoBehaviour
{
    CodeBlock previousBlock;
    CodeBlock nextBlock;
    public virtual void makeAction() {  }

    public CodeBlock getNextBlock()
    {
        return nextBlock;
    }

    public CodeBlock getPreviousBlock()
    {
        return previousBlock;
    }

    public void setNextBlock(CodeBlock codeBlock)
    {
        nextBlock = codeBlock;
    }

    public void setPreviousBlock(CodeBlock codeBlock)
    {
        previousBlock = codeBlock;
    }

}
