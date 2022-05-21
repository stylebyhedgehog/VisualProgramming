using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonalRatingElement : MonoBehaviour
{
    [SerializeField] private Text level;
    [SerializeField] private List<Star> stars;

    
    public void setLevel(string value)
    {
        level.text = "Уровень " + value;
    }

    public void fillStarsForRating(int rating)
    {
        for (int i = 0;  i <= rating - 1; i++)
        {
            stars[i].fillStar();
        }
    }
}
