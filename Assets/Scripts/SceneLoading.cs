using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    [SerializeField] Image progressBar;
    [SerializeField] Text text;
    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        progressBar.fillAmount = 0f;
        yield return new WaitForSeconds(2f);
        AsyncOperation operation = SceneManager.LoadSceneAsync("StartScene");
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            text.text = Math.Round(operation.progress*100).ToString()+"%";
            progressBar.fillAmount = operation.progress;
            if (operation.progress >= 0.9f)
            {
                text.text = "Подключение к БД";
                operation.allowSceneActivation = true;
            }
            yield return null;
        }

    }
}
