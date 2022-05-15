using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsPanel : MonoBehaviour
{
    [SerializeField] private Transform levelBtnsContainer;
    [SerializeField] private GameObject lvlBtnPrefab;

    [SerializeField] private Button toMainMenu;
    [SerializeField] private GameObject mainMenuPanel;
    void Start()
    {
        setLevels();
        Repository_Level.newLevelUnlocked += onLevelUnlocked;
        Repository_Level.levelChanged += onLevelChanged;
        toMainMenu.onClick.AddListener(() => ToMainMenu());
    }

    private void setLevels()
    {
        foreach (Model_Level level in Repository_Level.Instance.GetAll())
        {
            GameObject newGO = Instantiate(lvlBtnPrefab, levelBtnsContainer);
            LevelButton levelBtn = newGO.GetComponent<LevelButton>();
            levelBtn.setLevelIndex(level.Index);
            if (SaveSystem.Instance.getCurrentUser().Level < level.Index || Repository_Level.Instance.GetCurrentLevel().Index == level.Index)
            {
                levelBtn.Disable();
            }
        }

    }

    private void onLevelUnlocked(int index)
    {
        foreach (Transform child in levelBtnsContainer)
        {
            LevelButton levelButton = child.gameObject.GetComponent<LevelButton>();
            if (levelButton.getLevelIndex() == index)
            {
                levelButton.Enable();
            }
        }
    }

    private void onLevelChanged(int previous, int current)
    {
        foreach (Transform child in levelBtnsContainer)
        {
            LevelButton levelButton = child.gameObject.GetComponent<LevelButton>();
            if (levelButton.getLevelIndex() == previous)
            {
                levelButton.Enable();
            }
            if (levelButton.getLevelIndex() == current)
            {
                levelButton.Disable();
            }
        }
        gameObject.SetActive(false);
        mainMenuPanel.SetActive(false);
    }

    private void ToMainMenu()
    {
        gameObject.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

}
