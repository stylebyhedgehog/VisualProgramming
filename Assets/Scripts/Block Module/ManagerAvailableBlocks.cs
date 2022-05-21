using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        //TabsUI.tabOpened += HandleBlocksInTabs;
        Controller_Level.newLevelUnlocked += onNewLevelUnlocked;
        InitializeAvailableBlocks();
    }
 

    private void InitializeAvailableBlocks()
    {
        Model_User current_user = Controller_User.GetCurrentUser();
        int maxLevelIndex = current_user.AvailableLevels.Max(z=>z.Index);
        Model_Level maxLevel = Controller_Level.GetLevelByIndex(maxLevelIndex);
        foreach (Block_Type_Action action in maxLevel.availableBlocks)
        {
            AddBlock(action);
        }
    }

    private void onNewLevelUnlocked(Model_Level level)
    {
        foreach (Block_Type_Action action in level.availableBlocks)
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
