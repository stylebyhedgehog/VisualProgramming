using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopElement : MonoBehaviour
{
    [Space(20f)]
    [SerializeField] private Text Name;
    [SerializeField] private Image Image;
    [SerializeField] private Text Price;
    [SerializeField] private GameObject CoinIcon;
    [SerializeField] private Button actionButton;
    [SerializeField] private Text actionButtonText;
    private Model_Character character;

    public void Initialize(Model_Character character)
    {
        this.character = character;
        Name.text = character.Name;
        Image.sprite = character.CharacterSprite;
    }

    public void SetAsAvailableToPurchase()
    {
        CoinIcon.SetActive(true);
        Price.gameObject.SetActive(true);
        Price.text = ScorePattern.ConvertToString(character.Price);
        actionButtonText.text = "Купить";
    }
    public void SetAsPurchased()
    {
        CoinIcon.SetActive(false);
        Price.gameObject.SetActive(false);
        actionButtonText.text = "Выбрать";
    }

    public void SetAsSelected()
    {
        CoinIcon.SetActive(false);
        Price.gameObject.SetActive(false);
        actionButton.onClick.RemoveAllListeners();
        actionButtonText.text = "Выбрано";
    }
    public void OnPurchase(Model_Character character, UnityAction<Model_Character> action)
    {
        actionButton.onClick.RemoveAllListeners();
        actionButton.onClick.AddListener(() => action.Invoke(character));
    }
    public void OnSelect(Model_Character character, UnityAction<Model_Character> action)
    {
        actionButton.onClick.RemoveAllListeners();
        actionButton.onClick.AddListener(() => action.Invoke(character));
    }
}
