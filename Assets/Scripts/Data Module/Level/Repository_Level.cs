using System.Collections;
using UnityEngine;
using MongoDB.Driver;
using System.Collections.Generic;

public class Repository_Level : MonoBehaviour
{   
    private List<Model_Level> allLevels;

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
        Model_Level lvl0 = new Model_Level(0, "Наземный мир", "Теория", new Vector3(-1, -7, 0));
        Model_Level lvl1 = new Model_Level(1, "Наземный мир", "Теория", new Vector3(-4, -7, 0));
        allLevels = new List<Model_Level>() { lvl0, lvl1};
    }

    public List<Model_Level> GetAll()
    {
        return allLevels;
    } 

    public Model_Level GetByIndex(int index)
    {
        foreach (Model_Level model_Level in allLevels)
        {
            if (model_Level.Index == index)
            {
                return model_Level;
            }
        }
        return null;
    }


 
}
