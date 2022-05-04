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

    public bool hasPreviousBlock()
    {
        return (previousBlock != null);
    }

    public bool hasNextBlock()
    {
        return (nextBlock != null);
    }

    public void disconnectPreviousBlock()
    {
        this.previousBlock.nextBlock = null;
        this.previousBlock = null;
    }

    public void disconnectNextBlock()
    {
        this.nextBlock.previousBlock = null;
        this.nextBlock = null;
    }

    public CodeBlock getLastBlockInChain()
    {
        CodeBlock lastBlock = this;
        while (lastBlock.nextBlock != null)
        {
            lastBlock = lastBlock.nextBlock;
        }
        return lastBlock;
    }

   
}
