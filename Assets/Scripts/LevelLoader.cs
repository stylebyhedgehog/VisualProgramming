using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
      private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGO = collision.gameObject;
        if (collisionGO.name == "Player")
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        Repository_Level.Instance.ToNextLevel();
        
    }
}
