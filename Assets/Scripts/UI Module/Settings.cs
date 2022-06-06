using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] private Button toMainMenu;
    void Start()
    {
        InitializeButtonActions();
    }

    private void InitializeButtonActions()
    {
        toMainMenu.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
    }
}
