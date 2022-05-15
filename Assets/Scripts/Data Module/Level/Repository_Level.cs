using System.Collections;
using UnityEngine;
using MongoDB.Driver;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class Repository_Level : MonoBehaviour
{   
    [SerializeField]private List<Model_Level> allLevels;

    private Model_Level currentLevel;

    public static Repository_Level Instance;

    public static Action<int> newLevelUnlocked;
    public static Action<int, int> levelChanged;
    public static Action<Model_Level> levelLoaded;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        currentLevel = allLevels[0];
    }

    public List<Model_Level> GetAll()
    {
        return allLevels;
    } 

    public Model_Level GetLevelByIndex(int index)
    {
        return allLevels[index-1];
    }

    public Model_Level GetCurrentLevel()
    {
        return currentLevel;
    }

    public void ToNextLevel()
    {
        if (currentLevel.Index + 1 > SaveSystem.Instance.getCurrentUser().Level)
        {
            Repository_User.addScore(currentLevel.Reward);
            Repository_User.changeLevel(currentLevel.Index + 1);
            newLevelUnlocked?.Invoke(currentLevel.Index + 1);
        }
        currentLevel = allLevels[currentLevel.Index + 1];
        LoaderScene(currentLevel.Index);
    }
 
    public void ToLevel(int index)
    {
        levelChanged?.Invoke(currentLevel.Index, index);
        currentLevel = allLevels[index];
        LoaderScene(index);
    }

    private void LoaderScene(int index)
    {
        LoadingData.sceneToLoad = "Level" + index.ToString();
        SceneManager.LoadScene("LoadingScene");
        levelLoaded?.Invoke(currentLevel);
    }
  
}
