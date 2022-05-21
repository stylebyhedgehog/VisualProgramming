using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PersonalRating : MonoBehaviour
{
    [SerializeField] private Text maxLevel;
    [SerializeField] private Text avgRating;
    [SerializeField] private Transform rowsContainer;
    [SerializeField] private GameObject personalRatingRowPrefab;
    [SerializeField] private Button toMainMenu;
    void Start()
    {
        InitializeData();
        toMainMenu.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
    }

    private void InitializeData()
    {
        maxLevel.text = Controller_User.GetUserMaxLevel().ToString();
        avgRating.text = Controller_User.GetCurrentUserAverageRating().ToString();
        foreach (Available_Level level in Controller_User.GetCurrentUser().AvailableLevels)
        {
            GameObject newRow = Instantiate(personalRatingRowPrefab, rowsContainer);
            PersonalRatingElement element = newRow.GetComponent<PersonalRatingElement>();
            element.setLevel(level.Index.ToString());
            element.fillStarsForRating(level.Rating);
        }
    }
}
