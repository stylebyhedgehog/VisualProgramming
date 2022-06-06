using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alert : MonoBehaviour
{
    public static Alert Instance;
    [SerializeField] private GameObject alertWindow;
    [SerializeField] private Text alertText;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }
    public void showText(string text)
    {
        alertWindow.SetActive(true);
        alertText.text = text;
        StartCoroutine(showAlertAndHide());
    }

    private IEnumerator showAlertAndHide()
    {
        yield return new WaitForSeconds(2);
        alertWindow.SetActive(false);
    }
}
