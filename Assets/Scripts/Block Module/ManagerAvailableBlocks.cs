using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerAvailableBlocks : MonoBehaviour
{
    public static ManagerAvailableBlocks Instance;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }


    [SerializeField] private Blocks_Source Source;

    private void Start()
    {
        Draggable.startBlockDropped += onStartBlockDropped;
        TabsUI.tabOpened += HandleBlocksInTabs;
        Repository_Level.newLevelUnlocked += onNewLevelUnlocked;
        InitializeBlocks();
        SaveSystem.userLoggedIn += InitializeBlocks;
    }

    private void InitializeBlocks()
    {

        int userLevel = SaveSystem.Instance.getCurrentUser().Level;
        foreach (Model_Level level in Repository_Level.Instance.GetAll())
        {
            if (userLevel >= level.Index)
            {
                foreach (Block_Type_Action action in level.newBlocks)
                {
                    AddBlock(action);
                }

            }
        }
    }

    private void onNewLevelUnlocked(int level)
    {
        foreach (Block_Type_Action action in Repository_Level.Instance.GetLevelByIndex(level).newBlocks)
        {
            AddBlock(action);
        }
    }
    public void AddBlock(Block_Type_Action action)
    {
        Source.makeAvailableBlockWithAction(action);
    }

    public void HandleBlocksInTabs(int previous, int active)
    {
        Source.hideBlocksInTab(previous);
        Source.showBlocksInTab(active);
    }

    private void onStartBlockDropped()
    {
        Source.forbidBlockByTypeAction(Block_Type_Action.Start_Script);
    }

}
