using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PersonalRating : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text username;
    [SerializeField] private Text maxLevel;
    [SerializeField] private Text sumRating;
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
        Model_User currentUser = Controller_User.GetCurrentUser();
        image.sprite = Repository_Characters.Instance.GetByIndex(currentUser.CharacterId).CharacterSprite;
        username.text = currentUser.Username;
        maxLevel.text = Controller_User.GetUserMaxLevel(currentUser).ToString();
        sumRating.text = Controller_User.GetUserSumRating(currentUser).ToString();
        foreach (Available_Level level in currentUser.AvailableLevels)
        {
            GameObject newRow = Instantiate(personalRatingRowPrefab, rowsContainer);
            PersonalRatingElement element = newRow.GetComponent<PersonalRatingElement>();
            element.setLevel(level.Index.ToString());
            element.fillStarsForRating(level.Rating);
        }
    }
}
