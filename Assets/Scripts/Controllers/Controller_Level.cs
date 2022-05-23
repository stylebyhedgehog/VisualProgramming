using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller_Level
{ 
    public static Action<Model_Level> newLevelUnlocked;
    public static Action<Model_Level> levelChanged;
    public static Action<Model_Level> levelLoaded;

    public static void ToNextLevel()
    {
        Model_Level currentLevel = Repository_Level.Instance.GetCurrentLevel();
        Model_Level nextLevel = Repository_Level.Instance.GetNextLevel();
        if (!Controller_User.IsLevelAlreadyUnlocked(nextLevel.Index))
        {
            Controller_User.IncreaseUserScore(currentLevel.Reward);
            Controller_User.UnlockNewLevelForUser(nextLevel.Index);
            newLevelUnlocked?.Invoke(nextLevel);
        }
        int computedRating = RatingCalculator.calculateRating(Repository_Level.Instance.attempts, Repository_Level.Instance.isRequireBlockUsed);
        Controller_User.ChangeRatingForLevel(currentLevel.Index, computedRating);
    }

    public static void ToLevel(int index)
    {
        Model_Level nextLevel = Repository_Level.Instance.GetLevelByIndex(index);
        Controller_User.ChangeCurrentLevelForUser(nextLevel.Index);
        Repository_Level.Instance.SetCurrenLevel(nextLevel);
        LoadLevelScene(nextLevel);
        levelChanged?.Invoke(nextLevel);
    }

    public static void ToCurrentLevel()
    {
        Model_Level level = GetLevelByIndex(Controller_User.GetCurrentUser().CurrentLevel);
        Repository_Level.Instance.SetCurrenLevel(level);
        LoadLevelScene(level);
        levelChanged?.Invoke(level);
    }

    private static void LoadLevelScene(Model_Level level)
    {
        SceneManager.LoadScene(level.SceneName);
        levelLoaded?.Invoke(level);
    }

    public static Model_Level GetCurrentLevel()
    {
        return Repository_Level.Instance.GetCurrentLevel();
    }

    public static Model_Level GetNextLevel()
    {
        return Repository_Level.Instance.GetNextLevel();
    }

    public static Model_Level GetLevelByIndex(int index)
    {
        return Repository_Level.Instance.GetLevelByIndex(index);
    }

    public static List<Model_Level> GetAllLevels()
    {
        return Repository_Level.Instance.GetAll();
    }


}
