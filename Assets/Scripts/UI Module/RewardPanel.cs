using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RewardPanel : MonoBehaviour
{
    [SerializeField] private Button toMenu;
    [SerializeField] private Button toNextLevel;
    [SerializeField] private List<Star> stars;

    private int computedRating;
    public void Activate()
    {
        computedRating = RatingCalculator.calculateRating(Repository_Level.Instance.attempts, Repository_Level.Instance.isRequireBlockUsed);

        StartCoroutine(fillStars());
        
        toMenu.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
        var nextLevel = Controller_Level.GetNextLevel();
        if (nextLevel != null)
        {
            toNextLevel.onClick.AddListener(() => Controller_Level.ToLevel(nextLevel.Index));
        }
        else
        {
            toNextLevel.gameObject.SetActive(false);
        }
    }

    private IEnumerator fillStars()
    {
        for (int i = 0; i <= computedRating - 1; i++)
        {
            stars[i].fillStar();
            yield return new WaitForSeconds(0.5f);
        }
    }


}
