using UnityEngine;
using System.Collections.Generic;


public class Repository_Level : MonoBehaviour
{   
    [SerializeField]private List<Model_Level> allLevels;
    private Model_Level currentLevel;
    public int attempts = 0;
    public bool isRequireBlockUsed = false;

    public static Repository_Level Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        Controller_Auth.logIn_success += setLevelOnLogIn;
    }
    public List<Model_Level> GetAll()
    {
        return allLevels;
    } 
    public Model_Level GetLevelByIndex(int index)
    {
        foreach (Model_Level level in allLevels)
        {
            if (level.Index == index)
            { return level;}
        }
        return null;
    }
    public Model_Level GetCurrentLevel()
    {
        return currentLevel;
    }

    public Model_Level GetNextLevel()
    {
        return GetLevelByIndex(currentLevel.Index + 1);
    }

    public void SetCurrenLevel(Model_Level level)
    {
        attempts = 0;
        isRequireBlockUsed = false;
        currentLevel = level;
    }
 
    private void setLevelOnLogIn()
    {
        SetCurrenLevel(GetLevelByIndex(Controller_User.GetCurrentUser().CurrentLevel));
    }
}
