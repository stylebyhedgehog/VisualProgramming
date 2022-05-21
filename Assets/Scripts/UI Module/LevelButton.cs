using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text buttonText;
    private int lvlIndex;

    void Start()
    {
        button.onClick.AddListener(() => LoadLevel());
    }

    private void LoadLevel()
    {
        Controller_Level.ToLevel(lvlIndex);
    }

    public void setLevelIndex(int lvlIndex)
    {
        this.lvlIndex = lvlIndex;
        buttonText.text = lvlIndex.ToString();
    }

    public int getLevelIndex()
    {
        return lvlIndex;
    }

    public void Disable()
    {
        button.interactable = false;
    }

    public void Enable()
    {
        button.interactable = true;
    }
}
