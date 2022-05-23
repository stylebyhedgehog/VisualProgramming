
using UnityEngine;
using UnityEngine.UI;

public class RatingElement : MonoBehaviour
{
    [SerializeField] private Text username;
    [SerializeField] private Text score;
    [SerializeField] private Image image;


    public void SetUsername(string text)
    {
        username.text = text;
    }

    public void SetImage(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public void SetScore(string text)
    {
        score.text = text;
    }

    public void SetColor()
    {
        username.color = new Color(0, 0, 255, 255);
    }
}
