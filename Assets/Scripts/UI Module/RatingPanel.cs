using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RatingPanel : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform holder;
    [SerializeField] private Button toMainMenu;
    [SerializeField] private Button toPersonalRating;
    void Start()
    {
        InititializeTable();
        toMainMenu.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
        toPersonalRating.onClick.AddListener(() => SceneManager.LoadScene("PersonalRatingScene"));
    }

    private void InititializeTable()
    {
        List<Model_User> sortedUsers = Repository_User.GetAll();
        foreach (Model_User user in sortedUsers)
        {
            GameObject obj = Instantiate(prefab, holder);
            RatingElement ratingEl = obj.GetComponent<RatingElement>();
            ratingEl.SetImage(Repository_Characters.Instance.GetByIndex(user.CharacterId).CharacterSprite);
            ratingEl.SetUsername(user.Username);
            ratingEl.SetScore(Controller_User.GetUserAvarageRating(user).ToString());
            if (user.Username == Controller_Local.GetSavedUserUsername())
            {
                ratingEl.SetColor();
            }
        }
    }
}
