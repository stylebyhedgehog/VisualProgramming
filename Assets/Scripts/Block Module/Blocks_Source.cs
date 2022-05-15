using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Blocks_Source : MonoBehaviour
{
    [Header("Blocks first tab")]
    [SerializeField] private List<Block> blocks_1;

    [Header("Blocks second tab")]
    [SerializeField] private List<Block> blocks_2;

    [Header("Blocks third tab")]
    [SerializeField] private List<Block> blocks_3;

    private void Awake()
    {
        makeUnavailableAll();
        hideAll();
    }

    public List<Block> getBlocksByIndex(int index)
    {
        switch (index)
        {
            case 1:
                return blocks_1;
            case 2:
                return blocks_2;
            case 3:
                return blocks_3;
            default:
                return null;
        }
    }

    private Block getByTypeAction(Block_Type_Action action)
    {
        foreach (Block block in blocks_1.Concat(blocks_2).Concat(blocks_3))
        {
            if (block.type == action)
            {
                return block;
            }
        }
        return null;
        
    }

    public void makeAvailableBlockWithAction(Block_Type_Action action)
    {
        Block block = getByTypeAction(action);
        if (block != null)
        {
            block.makeAvailable();
        }
    }

    public void forbidBlockByTypeAction(Block_Type_Action action)
    {
        foreach (Block block in blocks_1.Concat(blocks_2).Concat(blocks_3))
        {
            if (block.type == action)
            {
                block.makeUnavailable();
            }
        }
    }
 
    public void hideBlocksInTab(int index)
    {
        List<Block> blocks = getBlocksByIndex(index);
        foreach (Block block in blocks)
        {
            block.Hide();
        }
        
    }

    public void showBlocksInTab(int index)
    {
        List<Block> blocks = getBlocksByIndex(index);
       
        foreach (Block block in blocks)
        {
            block.Show();
        }
    }

    public void makeAvailableAll()
    {
        foreach (Block block in blocks_1.Concat(blocks_2).Concat(blocks_3))
        {
            block.makeAvailable();
            block.Show();
        }
    }

    public void makeUnavailableAll()
    {
        foreach (Block block in blocks_1.Concat(blocks_2).Concat(blocks_3))
        {
            block.makeUnavailable();
        }
    }

    public void hideAll()
    {
        foreach (Block block in blocks_1.Concat(blocks_2).Concat(blocks_3))
        {
            block.Hide();
        }
    }
}
