using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsPanel : MonoBehaviour
{
    [SerializeField] private Transform levelBtnsContainer;
    [SerializeField] private GameObject lvlBtnPrefab;

    [SerializeField] private Button toMainMenu;
    void Start()
    {
        setLevels();
   /*     Controller_Level.newLevelUnlocked += onLevelUnlocked;
        Controller_Level.levelChanged += onLevelChanged;*/
        toMainMenu.onClick.AddListener(() => ToMainMenu());
    }

    private void setLevels()
    {
        foreach (Model_Level level in Controller_Level.GetAllLevels())
        {
            GameObject newGO = Instantiate(lvlBtnPrefab, levelBtnsContainer);
            LevelButton levelBtn = newGO.GetComponent<LevelButton>();
            levelBtn.setLevelIndex(level.Index);
            Model_User current_user = Controller_User.GetCurrentUser();
            if (!Controller_User.IsLevelAlreadyUnlocked(level.Index) || Controller_Level.GetCurrentLevel().Index == level.Index)
             {
                 levelBtn.Disable();
            }
            else
            {
                levelBtn.Enable();
            }
        }

    }



    private void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
