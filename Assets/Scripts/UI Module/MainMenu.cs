using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject buttonsTopContainer;
    [SerializeField] private GameObject welcomeGroup;

    [SerializeField] private Button play;
    [SerializeField] private Button levels;
    [SerializeField] private Button shop;

    [SerializeField] private Button logIn;
    [SerializeField] private Button logOut;

    [SerializeField] private GameObject logInPanel;
    [SerializeField] private GameObject levelPanel;
    void Start()
    {
        InitializeButtonActions();
        SaveSystem.userLoggedIn += OnUserLoggedIn;
        SaveSystem.userLoggedOut += OnUserLoggedOut;
        if (SaveSystem.Instance.isUserAuthorized())
        {
            OnUserLoggedIn();
        }
        else
        {
            OnUserLoggedOut();
        }
    }

    private void OnUserLoggedIn()
    {
        buttonsTopContainer.SetActive(true);
        logIn.gameObject.SetActive(false);
        logOut.gameObject.SetActive(true);
        welcomeGroup.SetActive(false);
    }

    private void OnUserLoggedOut()
    {
        buttonsTopContainer.SetActive(false);
        logIn.gameObject.SetActive(true);
        logOut.gameObject.SetActive(false);
        welcomeGroup.SetActive(true);
    }

    private void InitializeButtonActions()
    {
        play.onClick.AddListener(() => StartGame());
        logOut.onClick.AddListener(() => LogOut());
        logIn.onClick.AddListener(() => OpenLogInPanel());
        levels.onClick.AddListener(() => OpenLevelsPanel());
    }

    private void StartGame()
    {
        gameObject.SetActive(false);
    }
    private void LogOut()
    {
        SaveSystem.Instance.removeCurrentUser();
    }

    private void OpenLogInPanel()
    {
        logInPanel.SetActive(true);
    }

    private void OpenLevelsPanel()
    {
        levelPanel.SetActive(true);
    }
}
