using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Navigation : MonoBehaviour
{
    [SerializeField] private GameObject navigationUI;

    [SerializeField] private Button openCodePanelBtn;
    [SerializeField] private GameObject codePanel;

    public static Action codePanelOpened;

    [SerializeField] private Button openMainMenuBtn;
    [SerializeField] private GameObject mainMenu;
    void Start()
    {
        InitButtons();
        CodePanel.closeBtnClicked += showLTNavigationGroup;
    }

    private void InitButtons()
    {
        openCodePanelBtn.onClick.AddListener(()=> onCodePanelButtonClicked());
        openMainMenuBtn.onClick.AddListener(() => openMainMenu());
    }
    
    private void openMainMenu()
    {
        mainMenu.SetActive(true);
    }

    private void onCodePanelButtonClicked()
    {
        codePanel.SetActive(true);
        navigationUI.SetActive(false);
        codePanelOpened?.Invoke();
    }

    private void showLTNavigationGroup()
    {
        navigationUI.SetActive(true);
    }

    
}
