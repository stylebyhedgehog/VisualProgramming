using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject rewardPanel;
      private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGO = collision.gameObject;
        if (collisionGO.name == "Player")
        {
            collisionGO.SetActive(false);
            LoadScene();
        }
    }

    private void LoadScene()
    {
        rewardPanel.SetActive(true);
        rewardPanel.GetComponent<RewardPanel>().Activate();
        Controller_Level.ToNextLevel();

    }
}
