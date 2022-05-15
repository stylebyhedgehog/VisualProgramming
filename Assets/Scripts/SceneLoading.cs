using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    [SerializeField] Image progressBar;
    [SerializeField] GameObject camera;
    void Start()
    {
        if (camera && LoadingData.sceneToLoad != "Level1")
        {
            Destroy(camera);
        }
        StartCoroutine(LoadSceneAsync());
    }

    // Update is called once per frame
    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(LoadingData.sceneToLoad);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            progressBar.fillAmount = operation.progress;
            if (operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
            yield return null;
        }

    }
}
