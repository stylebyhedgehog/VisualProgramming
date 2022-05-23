using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private ShopElement shopElement;

    [SerializeField] private Button next;
    [SerializeField] private Button prev;
    [SerializeField] private Button toMainMenu;

    [SerializeField] private Text Score;
    [SerializeField] private Text Error;

    private Model_User currentUser;

    private int currentShownItemIndex = 1;
    void Start()
    {
        currentUser = Controller_User.GetCurrentUser();
        currentShownItemIndex = currentUser.CharacterId;
        Score.text = ScorePattern.ConvertToString(currentUser.Score);
        FillItem(Repository_Characters.Instance.GetByIndex(currentUser.CharacterId));
        AddShopEvents();
    }

  
    private void ShowNextItem()
    {
        if (currentShownItemIndex == Repository_Characters.Instance.GetAmount())
        {
            currentShownItemIndex = 1;
        }
        else
        {
            currentShownItemIndex = currentShownItemIndex + 1;
        }
        FillItem(Repository_Characters.Instance.GetByIndex(currentShownItemIndex));
    }

    private void ShowPrevItem()
    {
        if (currentShownItemIndex == 1)
        {
            currentShownItemIndex = Repository_Characters.Instance.GetAmount();
        }
        else
        {
            currentShownItemIndex = currentShownItemIndex - 1;
        }
        FillItem(Repository_Characters.Instance.GetByIndex(currentShownItemIndex));

    }


    private void FillItem(Model_Character character)
    {
        Error.text = "";
        shopElement.Initialize(character);

        if (currentUser.CharacterId == character.Index)
        {
            shopElement.SetAsSelected();
        }
        else
       if (currentUser.AvailableCharactersId.Contains(character.Index))
        {
            //Purchased boat
            shopElement.SetAsPurchased();
            shopElement.OnSelect(character, CharacterSelectedEvent);
        }
        else
        {
            //Need purchase
            shopElement.SetAsAvailableToPurchase();
            shopElement.OnPurchase(character, CharacterPurchasedEvent);
        }
    }

    private void CharacterSelectedEvent(Model_Character character)
    {
        currentUser.CharacterId = character.Index;
        shopElement.SetAsSelected();
    }

    private void CharacterPurchasedEvent(Model_Character character)
    {
        if (currentUser.Score >= character.Price)
        {
            currentUser.Score -= character.Price;
            currentUser.AvailableCharactersId.Add(character.Index);
            Score.text = ScorePattern.ConvertToString(currentUser.Score);
            shopElement.SetAsPurchased();
            shopElement.OnSelect(character, CharacterSelectedEvent);
        }
        else
        {
            Error.text = "Недостаточно очков";
            Debug.Log("<color=red> Not enough coins </color>");
        }
    }


    private void AddShopEvents()
    {
        next.onClick.AddListener(ShowNextItem);
        prev.onClick.AddListener(ShowPrevItem);
        toMainMenu.onClick.AddListener(ToMainMenu);
    }


    private void ToMainMenu()
    {
        Controller_User.UpdateUser(currentUser);
        SceneManager.LoadScene("MainMenu");
    }
}
