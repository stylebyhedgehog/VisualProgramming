using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabsUI : MonoBehaviour
{
    [Header("Tabs buttons")]
    [SerializeField] private Button tab_1;
    [SerializeField] private Button tab_2;
    [SerializeField] private Button tab_3;

    private GameObject activeTab;
    private int activeTabIndex;
    public static Action<int,int> tabOpened;


    void Start()
    {
        activeTabIndex = 1;
        openTab(tab_1.gameObject, 1);
        initTabAction(tab_1, 1);
        initTabAction(tab_2, 2);
        initTabAction(tab_3, 3);
    }

    private void initTabAction(Button tab, int index)
    {
        tab.onClick.AddListener(() => openTab(tab.gameObject, index));
    }

    public void openTab(GameObject tab, int index)
    {
        //change ui
        if (activeTab)
        {
            activeTab.GetComponent<Canvas>().sortingOrder = 90;
        }
        tab.GetComponent<Canvas>().sortingOrder = 110;

        //tabOpened?.Invoke(activeTabIndex, index);
        ManagerAvailableBlocks.Instance.HandleBlocksInTabs(activeTabIndex, index);
        
        //set new tab
        activeTab = tab;
        activeTabIndex = index;

    }
}
