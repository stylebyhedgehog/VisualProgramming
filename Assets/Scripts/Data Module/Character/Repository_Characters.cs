using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repository_Characters : MonoBehaviour
{
    public static Repository_Characters Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }
    [SerializeField] private List<Model_Character> allCharacters;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public List<Model_Character> GetAll()
    {
        return allCharacters;
    }
    public Model_Character GetByIndex(int index)
    {
        return allCharacters.Find(i => i.Index == index);
    }

    public int GetAmount()
    {
        return allCharacters.Count;
    }
}
