using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    [SerializeField] private GameObject navigationUI;

    [SerializeField] private Button openCodePanelBtn;
    [SerializeField] private GameObject codePanel;

    public static Action codePanelOpened;

    [SerializeField] private Button openMainMenuBtn;

    [SerializeField] private Text coins;
    [SerializeField] private Button helpButton;
    [SerializeField] private Helper helper;
  

    void Start()
    {
        coins.text = ScorePattern.ConvertToString(Controller_User.GetCurrentUser().Score);
        InitButtons();
        //CodePanel.closeBtnClicked += showLTNavigationGroup;
    }


    private void InitButtons()
    {
        openCodePanelBtn.onClick.AddListener(() => onCodePanelButtonClicked());
        openMainMenuBtn.onClick.AddListener(() => openMainMenu());
        helpButton.onClick.AddListener(() => helper.ShowHelpInfo());
    }

    private void openMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void onCodePanelButtonClicked()
    {
        codePanel.SetActive(true);
        navigationUI.SetActive(false);
        codePanelOpened?.Invoke();
    }

   /* private void showLTNavigationGroup()
    {
        navigationUI.SetActive(true);
    }*/



}
