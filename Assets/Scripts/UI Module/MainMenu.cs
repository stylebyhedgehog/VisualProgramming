using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button play;
    [SerializeField] private Button levels;
    [SerializeField] private Button rating;
    [SerializeField] private Button shop;
    [SerializeField] private Button settings;
    [SerializeField] private Button testMode;

    [SerializeField] private Button logOut;

    [SerializeField] private Text coins;
    [SerializeField] private Text lvl;

    void Start()
    {
        Model_User user = Controller_User.GetCurrentUser();
        lvl.text = user.CurrentLevel.ToString();
        coins.text = ScorePattern.ConvertToString(user.Score);
        InitializeButtonActions();
    }

   
    private void InitializeButtonActions()
    {
        play.onClick.AddListener(() => StartGame());
        logOut.onClick.AddListener(() => LogOut());
        levels.onClick.AddListener(() => OpenLevelsPanel());
        rating.onClick.AddListener(() => OpenRatingPanel());
        shop.onClick.AddListener(() => OpenShopPanel());
        settings.onClick.AddListener(() => OpenSettingsPanel());
        testMode.onClick.AddListener(() => ToTestMode());
    }

    private void StartGame()
    {
        Controller_Level.ToCurrentLevel();
    }
    private void LogOut()
    {
        Controller_Local.RemoveSavedUserAndForget();
        SceneManager.LoadScene("StartScene");

    }

    private void OpenLevelsPanel()
    {
        SceneManager.LoadScene("SelectLevelScene");
    }

    private void OpenRatingPanel()
    {
        SceneManager.LoadScene("RatingScene");
    }

    private void OpenShopPanel()
    {
        SceneManager.LoadScene("ShopScene");
    }
    private void OpenSettingsPanel()
    {
        SceneManager.LoadScene("SettingsScene");
    }
    private void ToTestMode()
    {
        Controller_Level.ToLevel(99);
    }
}
