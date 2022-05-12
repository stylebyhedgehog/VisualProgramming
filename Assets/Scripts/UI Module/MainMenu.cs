using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    void Start()
    {
        playButton.onClick.AddListener(() => startGame());
    }

    private void startGame()
    {
        gameObject.SetActive(false);


    }
}
